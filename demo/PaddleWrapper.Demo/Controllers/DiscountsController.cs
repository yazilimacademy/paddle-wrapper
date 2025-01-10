using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PaddleWrapper.Core.Interfaces;
using PaddleWrapper.Core.Models;
using PaddleWrapper.Core.Models.Discount;
using System.Threading.Tasks;

namespace PaddleWrapper.Demo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly ILogger<DiscountsController> _logger;

        public DiscountsController(IDiscountService discountService, ILogger<DiscountsController> logger)
        {
            _discountService = discountService;
            _logger = logger;
        }

        /// <summary>
        /// Lists all discounts
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<PaddleResponse<Discount[]>>> ListDiscounts()
        {
            return await _discountService.ListDiscountsAsync();
        }

        /// <summary>
        /// Gets a specific discount by ID
        /// </summary>
        [HttpGet("{discountId}")]
        public async Task<ActionResult<PaddleResponse<Discount>>> GetDiscount(string discountId)
        {
            return await _discountService.GetDiscountAsync(discountId);
        }

        /// <summary>
        /// Creates a new discount
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<PaddleResponse<Discount>>> CreateDiscount([FromBody] Discount discount)
        {
            return await _discountService.CreateDiscountAsync(discount);
        }

        /// <summary>
        /// Updates an existing discount
        /// </summary>
        [HttpPatch("{discountId}")]
        public async Task<ActionResult<PaddleResponse<Discount>>> UpdateDiscount(string discountId, [FromBody] Discount discount)
        {
            return await _discountService.UpdateDiscountAsync(discountId, discount);
        }

        /// <summary>
        /// Deletes a discount
        /// </summary>
        [HttpDelete("{discountId}")]
        public async Task<IActionResult> DeleteDiscount(string discountId)
        {
            var response = await _discountService.DeleteDiscountAsync(discountId);
            if (!response.Success)
            {
                return BadRequest(response.Error);
            }
            return NoContent();
        }
    }
} 