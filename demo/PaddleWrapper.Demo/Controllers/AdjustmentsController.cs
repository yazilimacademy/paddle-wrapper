using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PaddleWrapper.Core.Interfaces;
using PaddleWrapper.Core.Models.Adjustment;
using System.Threading.Tasks;

namespace PaddleWrapper.Demo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdjustmentsController : ControllerBase
    {
        private readonly IAdjustmentService _adjustmentService;
        private readonly ILogger<AdjustmentsController> _logger;

        public AdjustmentsController(IAdjustmentService adjustmentService, ILogger<AdjustmentsController> logger)
        {
            _adjustmentService = adjustmentService;
            _logger = logger;
        }

        /// <summary>
        /// Lists all adjustments
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<AdjustmentResponse>> ListAdjustments()
        {
            return await _adjustmentService.ListAdjustmentsAsync();
        }

        /// <summary>
        /// Gets a specific adjustment by ID
        /// </summary>
        [HttpGet("{adjustmentId}")]
        public async Task<ActionResult<Adjustment>> GetAdjustment(string adjustmentId)
        {
            return await _adjustmentService.GetAdjustmentAsync(adjustmentId);
        }

        /// <summary>
        /// Creates a new adjustment
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Adjustment>> CreateAdjustment([FromBody] CreateAdjustmentRequest request)
        {
            return await _adjustmentService.CreateAdjustmentAsync(request);
        }

        /// <summary>
        /// Previews an adjustment
        /// </summary>
        [HttpPost("preview")]
        public async Task<ActionResult<AdjustmentPreview>> PreviewAdjustment([FromBody] PreviewAdjustmentRequest request)
        {
            return await _adjustmentService.PreviewAdjustmentAsync(request);
        }
    }
} 