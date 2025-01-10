using Microsoft.AspNetCore.Mvc;
using PaddleWrapper.Interfaces;

namespace PaddleWrapperDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PricesController : ControllerBase
    {
        private readonly IPriceService _priceService;

        public PricesController(IPriceService priceService)
        {
            _priceService = priceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPrices()
        {
            PaddleWrapper.Models.Common.PaddleResponse<List<PaddleWrapper.Models.Prices.Price>> result = await _priceService.ListPricesAsync();
            return Ok(result);
        }

        [HttpGet("products/{productId}")]
        public async Task<IActionResult> GetProductPrices(string productId)
        {
            PaddleWrapper.Models.Common.PaddleResponse<List<PaddleWrapper.Models.Prices.Price>> result = await _priceService.ListProductPricesAsync(productId);
            return Ok(result);
        }
    }
}
