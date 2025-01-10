using Microsoft.AspNetCore.Mvc;
using PaddleWrapper.Interfaces;
using PaddleWrapper.Models.Discounts;
using System.Threading.Tasks;

namespace PaddleDemo.Api.Controllers
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
            var result = await _discountService.ListDiscountsAsync();
            return Ok(result);
        }

        [HttpGet("{discountId}")]
        public async Task<IActionResult> GetDiscount(string discountId)
        {
            var result = await _discountService.GetDiscountAsync(discountId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscount([FromBody] Discount discount)
        {
            var result = await _discountService.CreateDiscountAsync(discount);
            return Ok(result);
        }

        [HttpPatch("{discountId}")]
        public async Task<IActionResult> UpdateDiscount(string discountId, [FromBody] Discount discount)
        {
            var result = await _discountService.UpdateDiscountAsync(discountId, discount);
            return Ok(result);
        }

        [HttpGet("products/{productId}")]
        public async Task<IActionResult> GetProductDiscounts(string productId)
        {
            var result = await _discountService.ListProductDiscountsAsync(productId);
            return Ok(result);
        }

        [HttpGet("prices/{priceId}")]
        public async Task<IActionResult> GetPriceDiscounts(string priceId)
        {
            var result = await _discountService.ListPriceDiscountsAsync(priceId);
            return Ok(result);
        }
    }
}
