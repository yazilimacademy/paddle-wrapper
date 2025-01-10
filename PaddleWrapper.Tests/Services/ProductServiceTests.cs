using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using PaddleWrapper.Core.Configuration;
using PaddleWrapper.Core.Interfaces;
using PaddleWrapper.Core.Models;
using PaddleWrapper.Core.Models.Product;
using PaddleWrapper.Core.Services;
using PaddleWrapper.Core.Services.Cache;
using Xunit;

namespace PaddleWrapper.Tests.Services
{
    public class ProductServiceTests
    {
        private readonly Mock<IPaddleLogger> _loggerMock;
        private readonly Mock<IPaddleCache> _cacheMock;
        private readonly Mock<IOptions<PaddleOptions>> _optionsMock;
        private readonly PaddleOptions _options;

        public ProductServiceTests()
        {
            _loggerMock = new Mock<IPaddleLogger>();
            _cacheMock = new Mock<IPaddleCache>();
            _options = new PaddleOptions
            {
                ApiKey = "test_api_key",
                VendorId = "test_vendor_id"
            };
            _optionsMock = new Mock<IOptions<PaddleOptions>>();
            _optionsMock.Setup(x => x.Value).Returns(_options);
        }

        [Fact]
        public async Task GetProductAsync_ValidId_ReturnsProduct()
        {
            // Arrange
            Product expectedProduct = new() { Id = 1, Name = "Test Product" };
            PaddleResponse<Product> expectedResponse = new() { Success = true, Response = expectedProduct };

            HttpClient httpClient = new(new MockHttpMessageHandler(expectedResponse));
            PaddleHttpClient paddleHttpClient = new(httpClient, _optionsMock.Object, _loggerMock.Object);
            ProductService productService = new(paddleHttpClient, _cacheMock.Object, _loggerMock.Object);

            // Act
            PaddleResponse<Product> result = await productService.GetProductAsync(1);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Response.Should().NotBeNull();
            result.Response.Id.Should().Be(1);
            result.Response.Name.Should().Be("Test Product");
        }

        [Fact]
        public async Task ListProductsAsync_ReturnsProducts()
        {
            // Arrange
            Product[] expectedProducts = new[]
            {
                new Product { Id = 1, Name = "Product 1" },
                new Product { Id = 2, Name = "Product 2" }
            };
            PaddleResponse<Product[]> expectedResponse = new() { Success = true, Response = expectedProducts };

            HttpClient httpClient = new(new MockHttpMessageHandler(expectedResponse));
            PaddleHttpClient paddleHttpClient = new(httpClient, _optionsMock.Object, _loggerMock.Object);
            ProductService productService = new(paddleHttpClient, _cacheMock.Object, _loggerMock.Object);

            // Act
            PaddleResponse<Product[]> result = await productService.ListProductsAsync();

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Response.Should().NotBeNull();
            result.Response.Should().HaveCount(2);
            result.Response[0].Name.Should().Be("Product 1");
            result.Response[1].Name.Should().Be("Product 2");
        }

        [Fact]
        public async Task CreateProductAsync_ValidProduct_ReturnsCreatedProduct()
        {
            // Arrange
            Product newProduct = new() { Name = "New Product", BasePrice = 99.99m };
            PaddleResponse<Product> expectedResponse = new()
            {
                Success = true,
                Response = new Product { Id = 1, Name = "New Product", BasePrice = 99.99m }
            };

            HttpClient httpClient = new(new MockHttpMessageHandler(expectedResponse));
            PaddleHttpClient paddleHttpClient = new(httpClient, _optionsMock.Object, _loggerMock.Object);
            ProductService productService = new(paddleHttpClient, _cacheMock.Object, _loggerMock.Object);

            // Act
            PaddleResponse<Product> result = await productService.CreateProductAsync(newProduct);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Response.Should().NotBeNull();
            result.Response.Id.Should().Be(1);
            result.Response.Name.Should().Be("New Product");
            result.Response.BasePrice.Should().Be(99.99m);
        }

        [Fact]
        public async Task UpdateProductAsync_ValidProduct_ReturnsUpdatedProduct()
        {
            // Arrange
            Product updatedProduct = new() { Id = 1, Name = "Updated Product", BasePrice = 149.99m };
            PaddleResponse<Product> expectedResponse = new()
            {
                Success = true,
                Response = new Product { Id = 1, Name = "Updated Product", BasePrice = 149.99m }
            };

            HttpClient httpClient = new(new MockHttpMessageHandler(expectedResponse));
            PaddleHttpClient paddleHttpClient = new(httpClient, _optionsMock.Object, _loggerMock.Object);
            ProductService productService = new(paddleHttpClient, _cacheMock.Object, _loggerMock.Object);

            // Act
            PaddleResponse<Product> result = await productService.UpdateProductAsync(1, updatedProduct);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Response.Should().NotBeNull();
            result.Response.Id.Should().Be(1);
            result.Response.Name.Should().Be("Updated Product");
            result.Response.BasePrice.Should().Be(149.99m);
        }
    }
}