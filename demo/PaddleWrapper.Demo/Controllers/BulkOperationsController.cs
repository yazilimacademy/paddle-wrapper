using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PaddleWrapper.Core.Interfaces;
using PaddleWrapper.Core.Models.Bulk;
using System.Threading.Tasks;

namespace PaddleWrapper.Demo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BulkOperationsController : ControllerBase
    {
        private readonly IBulkService _bulkService;
        private readonly ILogger<BulkOperationsController> _logger;

        public BulkOperationsController(IBulkService bulkService, ILogger<BulkOperationsController> logger)
        {
            _bulkService = bulkService;
            _logger = logger;
        }

        /// <summary>
        /// Creates a bulk operation
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<BulkOperation>> CreateBulkOperation([FromBody] CreateBulkOperationRequest request)
        {
            return await _bulkService.CreateBulkOperationAsync(request);
        }

        /// <summary>
        /// Gets a specific bulk operation by ID
        /// </summary>
        [HttpGet("{operationId}")]
        public async Task<ActionResult<BulkOperation>> GetBulkOperation(string operationId)
        {
            return await _bulkService.GetBulkOperationAsync(operationId);
        }

        /// <summary>
        /// Lists all bulk operations
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<BulkOperationResponse>> ListBulkOperations()
        {
            return await _bulkService.ListBulkOperationsAsync();
        }

        /// <summary>
        /// Updates a bulk operation
        /// </summary>
        [HttpPatch("{operationId}")]
        public async Task<ActionResult<BulkOperation>> UpdateBulkOperation(string operationId, [FromBody] UpdateBulkOperationRequest request)
        {
            return await _bulkService.UpdateBulkOperationAsync(operationId, request);
        }
    }
} 