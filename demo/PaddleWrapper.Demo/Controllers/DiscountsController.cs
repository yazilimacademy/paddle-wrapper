using Microsoft.AspNetCore.Mvc;
using PaddleWrapper.Interfaces;
using PaddleWrapper.Models.Discounts;

namespace PaddleWrapperDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDiscounts()
        {
            PaddleWrapper.Models.Common.PaddleResponse<List<Discount>> result = await _discountService.ListDiscountsAsync();
            return Ok(result);
        }

        [HttpGet("{discountId}")]
        public async Task<IActionResult> GetDiscount(string discountId)
        {
            PaddleWrapper.Models.Common.PaddleResponse<Discount> result = await _discountService.GetDiscountAsync(discountId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscount([FromBody] Discount discount)
        {
            PaddleWrapper.Models.Common.PaddleResponse<Discount> result = await _discountService.CreateDiscountAsync(discount);
            return Ok(result);
        }

        [HttpPatch("{discountId}")]
        public async Task<IActionResult> UpdateDiscount(string discountId, [FromBody] Discount discount)
        {
            PaddleWrapper.Models.Common.PaddleResponse<Discount> result = await _discountService.UpdateDiscountAsync(discountId, discount);
            return Ok(result);
        }

        [HttpGet("products/{productId}")]
        public async Task<IActionResult> GetProductDiscounts(string productId)
        {
            PaddleWrapper.Models.Common.PaddleResponse<List<Discount>> result = await _discountService.ListProductDiscountsAsync(productId);
            return Ok(result);
        }

        [HttpGet("prices/{priceId}")]
        public async Task<IActionResult> GetPriceDiscounts(string priceId)
        {
            PaddleWrapper.Models.Common.PaddleResponse<List<Discount>> result = await _discountService.ListPriceDiscountsAsync(priceId);
            return Ok(result);
        }
    }
}
