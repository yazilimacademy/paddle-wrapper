using Microsoft.AspNetCore.Mvc;
using PaddleWrapper.Interfaces;
using PaddleWrapper.Models.Products;

namespace PaddleWrapperDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            PaddleWrapper.Models.Common.PaddleResponse<List<Product>> result = await _productService.ListProductsAsync();
            return Ok(result);
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProduct(string productId)
        {
            PaddleWrapper.Models.Common.PaddleResponse<Product> result = await _productService.GetProductAsync(productId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            PaddleWrapper.Models.Common.PaddleResponse<Product> result = await _productService.CreateProductAsync(product);
            return Ok(result);
        }

        [HttpPatch("{productId}")]
        public async Task<IActionResult> UpdateProduct(string productId, [FromBody] Product product)
        {
            PaddleWrapper.Models.Common.PaddleResponse<Product> result = await _productService.UpdateProductAsync(productId, product);
            return Ok(result);
        }
    }
}
