using Microsoft.Extensions.Logging;
using Moq;
using PaddleWrapper.Interfaces;
using PaddleWrapper.Models.Common;
using PaddleWrapper.Models.Discounts;
using PaddleWrapper.Services;

namespace PaddleWrapper.Tests.Services
{
    public class DiscountServiceTests
    {
        private readonly Mock<IPaddleClient> _mockClient;
        private readonly Mock<ILogger<DiscountService>> _mockLogger;
        private readonly DiscountService _service;

        public DiscountServiceTests()
        {
            _mockClient = new Mock<IPaddleClient>();
            _mockLogger = new Mock<ILogger<DiscountService>>();
            _service = new DiscountService(_mockClient.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task ListDiscountsAsync_ShouldReturnDiscounts()
        {
            // Arrange
            PaddleResponse<List<Discount>> expectedResponse = new()
            {
                Data = new List<Discount>
                {
                    new() { Id = "dsc_1", Code = "DISCOUNT1" },
                    new() { Id = "dsc_2", Code = "DISCOUNT2" }
                }
            };

            _mockClient
                .Setup(x => x.GetAsync<PaddleResponse<List<Discount>>>("/discounts", It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            PaddleResponse<List<Discount>> result = await _service.ListDiscountsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Data.Count);
            Assert.Equal("dsc_1", result.Data[0].Id);
            Assert.Equal("dsc_2", result.Data[1].Id);
        }

        [Fact]
        public async Task GetDiscountAsync_WithValidId_ShouldReturnDiscount()
        {
            // Arrange
            string discountId = "dsc_1";
            PaddleResponse<Discount> expectedResponse = new()
            {
                Data = new Discount { Id = discountId, Code = "DISCOUNT1" }
            };

            _mockClient
                .Setup(x => x.GetAsync<PaddleResponse<Discount>>($"/discounts/{discountId}", It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            PaddleResponse<Discount> result = await _service.GetDiscountAsync(discountId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(discountId, result.Data.Id);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task GetDiscountAsync_WithInvalidId_ShouldThrowArgumentException(string discountId)
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _service.GetDiscountAsync(discountId));
        }

        [Fact]
        public async Task CreateDiscountAsync_WithValidDiscount_ShouldReturnCreatedDiscount()
        {
            // Arrange
            Discount discount = new() { Code = "NEWDISCOUNT" };
            PaddleResponse<Discount> expectedResponse = new()
            {
                Data = new Discount { Id = "dsc_1", Code = "NEWDISCOUNT" }
            };

            _mockClient
                .Setup(x => x.PostAsync<Discount, PaddleResponse<Discount>>("/discounts", discount, It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            PaddleResponse<Discount> result = await _service.CreateDiscountAsync(discount);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("dsc_1", result.Data.Id);
            Assert.Equal(discount.Code, result.Data.Code);
        }

        [Fact]
        public async Task CreateDiscountAsync_WithNullDiscount_ShouldThrowArgumentNullException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _service.CreateDiscountAsync(null));
        }

        [Fact]
        public async Task UpdateDiscountAsync_WithValidDiscount_ShouldReturnUpdatedDiscount()
        {
            // Arrange
            string discountId = "dsc_1";
            Discount discount = new() { Code = "UPDATEDDISCOUNT" };
            PaddleResponse<Discount> expectedResponse = new()
            {
                Data = new Discount { Id = discountId, Code = "UPDATEDDISCOUNT" }
            };

            _mockClient
                .Setup(x => x.PatchAsync<Discount, PaddleResponse<Discount>>($"/discounts/{discountId}", discount, It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            PaddleResponse<Discount> result = await _service.UpdateDiscountAsync(discountId, discount);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(discountId, result.Data.Id);
            Assert.Equal(discount.Code, result.Data.Code);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task UpdateDiscountAsync_WithInvalidId_ShouldThrowArgumentException(string discountId)
        {
            // Arrange
            Discount discount = new() { Code = "DISCOUNT" };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _service.UpdateDiscountAsync(discountId, discount));
        }

        [Fact]
        public async Task UpdateDiscountAsync_WithNullDiscount_ShouldThrowArgumentNullException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _service.UpdateDiscountAsync("dsc_1", null));
        }

        [Fact]
        public async Task ListProductDiscountsAsync_WithValidProductId_ShouldReturnDiscounts()
        {
            // Arrange
            string productId = "prod_1";
            PaddleResponse<List<Discount>> expectedResponse = new()
            {
                Data = new List<Discount>
                {
                    new() { Id = "dsc_1", Code = "DISCOUNT1" },
                    new() { Id = "dsc_2", Code = "DISCOUNT2" }
                }
            };

            _mockClient
                .Setup(x => x.GetAsync<PaddleResponse<List<Discount>>>($"/discounts?product_id={productId}", It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            PaddleResponse<List<Discount>> result = await _service.ListProductDiscountsAsync(productId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Data.Count);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ListProductDiscountsAsync_WithInvalidProductId_ShouldThrowArgumentException(string productId)
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _service.ListProductDiscountsAsync(productId));
        }

        [Fact]
        public async Task ListPriceDiscountsAsync_WithValidPriceId_ShouldReturnDiscounts()
        {
            // Arrange
            string priceId = "pri_1";
            PaddleResponse<List<Discount>> expectedResponse = new()
            {
                Data = new List<Discount>
                {
                    new() { Id = "dsc_1", Code = "DISCOUNT1" },
                    new() { Id = "dsc_2", Code = "DISCOUNT2" }
                }
            };

            _mockClient
                .Setup(x => x.GetAsync<PaddleResponse<List<Discount>>>($"/discounts?price_id={priceId}", It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            PaddleResponse<List<Discount>> result = await _service.ListPriceDiscountsAsync(priceId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Data.Count);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ListPriceDiscountsAsync_WithInvalidPriceId_ShouldThrowArgumentException(string priceId)
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _service.ListPriceDiscountsAsync(priceId));
        }
    }
}