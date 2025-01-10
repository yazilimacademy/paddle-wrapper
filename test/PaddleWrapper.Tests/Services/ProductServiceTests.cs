using Microsoft.Extensions.Logging;
using Moq;
using PaddleWrapper.Interfaces;
using PaddleWrapper.Models.Common;
using PaddleWrapper.Models.Products;
using PaddleWrapper.Services;

namespace PaddleWrapper.Tests.Services
{
    public class ProductServiceTests
    {
        private readonly Mock<IPaddleClient> _mockClient;
        private readonly Mock<ILogger<ProductService>> _mockLogger;
        private readonly ProductService _service;

        public ProductServiceTests()
        {
            _mockClient = new Mock<IPaddleClient>();
            _mockLogger = new Mock<ILogger<ProductService>>();
            _service = new ProductService(_mockClient.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task ListProductsAsync_ShouldReturnProducts()
        {
            // Arrange
            PaddleResponse<List<Product>> expectedResponse = new()
            {
                Data = new List<Product>
                {
                    new() { Id = "prod_1", Name = "Test Product 1" },
                    new() { Id = "prod_2", Name = "Test Product 2" }
                }
            };

            _mockClient
                .Setup(x => x.GetAsync<PaddleResponse<List<Product>>>("/products", It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            PaddleResponse<List<Product>> result = await _service.ListProductsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Data.Count);
            Assert.Equal("prod_1", result.Data[0].Id);
            Assert.Equal("prod_2", result.Data[1].Id);
        }

        [Fact]
        public async Task GetProductAsync_WithValidId_ShouldReturnProduct()
        {
            // Arrange
            string productId = "prod_1";
            PaddleResponse<Product> expectedResponse = new()
            {
                Data = new Product { Id = productId, Name = "Test Product" }
            };

            _mockClient
                .Setup(x => x.GetAsync<PaddleResponse<Product>>($"/products/{productId}", It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            PaddleResponse<Product> result = await _service.GetProductAsync(productId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(productId, result.Data.Id);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task GetProductAsync_WithInvalidId_ShouldThrowArgumentException(string productId)
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _service.GetProductAsync(productId));
        }

        [Fact]
        public async Task CreateProductAsync_WithValidProduct_ShouldReturnCreatedProduct()
        {
            // Arrange
            Product product = new() { Name = "New Product" };
            PaddleResponse<Product> expectedResponse = new()
            {
                Data = new Product { Id = "prod_1", Name = "New Product" }
            };

            _mockClient
                .Setup(x => x.PostAsync<Product, PaddleResponse<Product>>("/products", product, It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            PaddleResponse<Product> result = await _service.CreateProductAsync(product);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("prod_1", result.Data.Id);
            Assert.Equal(product.Name, result.Data.Name);
        }

        [Fact]
        public async Task CreateProductAsync_WithNullProduct_ShouldThrowArgumentNullException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _service.CreateProductAsync(null));
        }

        [Fact]
        public async Task UpdateProductAsync_WithValidProduct_ShouldReturnUpdatedProduct()
        {
            // Arrange
            string productId = "prod_1";
            Product product = new() { Name = "Updated Product" };
            PaddleResponse<Product> expectedResponse = new()
            {
                Data = new Product { Id = productId, Name = "Updated Product" }
            };

            _mockClient
                .Setup(x => x.PatchAsync<Product, PaddleResponse<Product>>($"/products/{productId}", product, It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            PaddleResponse<Product> result = await _service.UpdateProductAsync(productId, product);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(productId, result.Data.Id);
            Assert.Equal(product.Name, result.Data.Name);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task UpdateProductAsync_WithInvalidId_ShouldThrowArgumentException(string productId)
        {
            // Arrange
            Product product = new() { Name = "Test Product" };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _service.UpdateProductAsync(productId, product));
        }

        [Fact]
        public async Task UpdateProductAsync_WithNullProduct_ShouldThrowArgumentNullException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _service.UpdateProductAsync("prod_1", null));
        }
    }
}