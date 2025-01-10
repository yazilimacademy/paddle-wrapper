using Microsoft.AspNetCore.Mvc;
using PaddleWrapper.Core.Models.Bulk;

namespace PaddleWrapper.Demo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BulkOperationsController : ControllerBase
    {
        private readonly IBulkOperationHandler<object, object> _bulkService;
        private readonly ILogger<BulkOperationsController> _logger;

        public BulkOperationsController(IBulkOperationHandler<object, object> bulkService, ILogger<BulkOperationsController> logger)
        {
            _bulkService = bulkService;
            _logger = logger;
        }

        /// <summary>
        /// Lists all bulk operations
        /// </summary>
        [HttpGet]
        public ActionResult<BulkOperationStatus> GetStatus()
        {
            return Ok(_bulkService.GetStatus());
        }

        /// <summary>
        /// Gets operation progress
        /// </summary>
        [HttpGet("progress")]
        public ActionResult<double> GetProgress()
        {
            return Ok(_bulkService.GetProgress());
        }

        /// <summary>
        /// Creates a bulk operation
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<BulkOperationResult<object>>> ProcessBulkOperation([FromBody] object[] items)
        {
            BulkOperationOptions options = new()
            {
                MaxDegreeOfParallelism = 5,
                BatchSize = 100,
                DelayBetweenBatches = 1000,
                ContinueOnError = true
            };

            return await _bulkService.ProcessAsync(items, options);
        }
    }
}