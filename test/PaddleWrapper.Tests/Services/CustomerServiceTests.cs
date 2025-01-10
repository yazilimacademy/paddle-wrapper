using Microsoft.Extensions.Logging;
using Moq;
using PaddleWrapper.Interfaces;
using PaddleWrapper.Models.Common;
using PaddleWrapper.Models.Customers;
using PaddleWrapper.Services;

namespace PaddleWrapper.Tests.Services
{
    public class CustomerServiceTests
    {
        private readonly Mock<IPaddleClient> _mockClient;
        private readonly Mock<ILogger<CustomerService>> _mockLogger;
        private readonly CustomerService _service;

        public CustomerServiceTests()
        {
            _mockClient = new Mock<IPaddleClient>();
            _mockLogger = new Mock<ILogger<CustomerService>>();
            _service = new CustomerService(_mockClient.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task ListCustomersAsync_ShouldReturnCustomers()
        {
            // Arrange
            PaddleResponse<List<Customer>> expectedResponse = new()
            {
                Data = new List<Customer>
                {
                    new() { Id = "ctm_1", Email = "customer1@test.com" },
                    new() { Id = "ctm_2", Email = "customer2@test.com" }
                }
            };

            _mockClient
                .Setup(x => x.GetAsync<PaddleResponse<List<Customer>>>("/customers", It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            PaddleResponse<List<Customer>> result = await _service.ListCustomersAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Data.Count);
            Assert.Equal("ctm_1", result.Data[0].Id);
            Assert.Equal("ctm_2", result.Data[1].Id);
        }

        [Fact]
        public async Task GetCustomerAsync_WithValidId_ShouldReturnCustomer()
        {
            // Arrange
            string customerId = "ctm_1";
            PaddleResponse<Customer> expectedResponse = new()
            {
                Data = new Customer { Id = customerId, Email = "customer@test.com" }
            };

            _mockClient
                .Setup(x => x.GetAsync<PaddleResponse<Customer>>($"/customers/{customerId}", It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            PaddleResponse<Customer> result = await _service.GetCustomerAsync(customerId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(customerId, result.Data.Id);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task GetCustomerAsync_WithInvalidId_ShouldThrowArgumentException(string customerId)
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _service.GetCustomerAsync(customerId));
        }

        [Fact]
        public async Task CreateCustomerAsync_WithValidCustomer_ShouldReturnCreatedCustomer()
        {
            // Arrange
            Customer customer = new() { Email = "newcustomer@test.com" };
            PaddleResponse<Customer> expectedResponse = new()
            {
                Data = new Customer { Id = "ctm_1", Email = "newcustomer@test.com" }
            };

            _mockClient
                .Setup(x => x.PostAsync<Customer, PaddleResponse<Customer>>("/customers", customer, It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            PaddleResponse<Customer> result = await _service.CreateCustomerAsync(customer);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("ctm_1", result.Data.Id);
            Assert.Equal(customer.Email, result.Data.Email);
        }

        [Fact]
        public async Task CreateCustomerAsync_WithNullCustomer_ShouldThrowArgumentNullException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _service.CreateCustomerAsync(null));
        }

        [Fact]
        public async Task UpdateCustomerAsync_WithValidCustomer_ShouldReturnUpdatedCustomer()
        {
            // Arrange
            string customerId = "ctm_1";
            Customer customer = new() { Email = "updated@test.com" };
            PaddleResponse<Customer> expectedResponse = new()
            {
                Data = new Customer { Id = customerId, Email = "updated@test.com" }
            };

            _mockClient
                .Setup(x => x.PatchAsync<Customer, PaddleResponse<Customer>>($"/customers/{customerId}", customer, It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            PaddleResponse<Customer> result = await _service.UpdateCustomerAsync(customerId, customer);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(customerId, result.Data.Id);
            Assert.Equal(customer.Email, result.Data.Email);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task UpdateCustomerAsync_WithInvalidId_ShouldThrowArgumentException(string customerId)
        {
            // Arrange
            Customer customer = new() { Email = "test@test.com" };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _service.UpdateCustomerAsync(customerId, customer));
        }

        [Fact]
        public async Task UpdateCustomerAsync_WithNullCustomer_ShouldThrowArgumentNullException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _service.UpdateCustomerAsync("ctm_1", null));
        }

        [Fact]
        public async Task ListCustomerAddressesAsync_WithValidCustomerId_ShouldReturnAddresses()
        {
            // Arrange
            string customerId = "ctm_1";
            PaddleResponse<List<Address>> expectedResponse = new()
            {
                Data = new List<Address>
                {
                    new() { Id = "add_1", CountryCode = "TR" },
                    new() { Id = "add_2", CountryCode = "US" }
                }
            };

            _mockClient
                .Setup(x => x.GetAsync<PaddleResponse<List<Address>>>($"/customers/{customerId}/addresses", It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            PaddleResponse<List<Address>> result = await _service.ListCustomerAddressesAsync(customerId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Data.Count);
            Assert.Equal("add_1", result.Data[0].Id);
            Assert.Equal("add_2", result.Data[1].Id);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ListCustomerAddressesAsync_WithInvalidCustomerId_ShouldThrowArgumentException(string customerId)
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _service.ListCustomerAddressesAsync(customerId));
        }

        [Fact]
        public async Task CreateCustomerAddressAsync_WithValidAddress_ShouldReturnCreatedAddress()
        {
            // Arrange
            string customerId = "ctm_1";
            Address address = new() { CountryCode = "TR" };
            PaddleResponse<Address> expectedResponse = new()
            {
                Data = new Address { Id = "add_1", CountryCode = "TR" }
            };

            _mockClient
                .Setup(x => x.PostAsync<Address, PaddleResponse<Address>>($"/customers/{customerId}/addresses", address, It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            PaddleResponse<Address> result = await _service.CreateCustomerAddressAsync(customerId, address);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("add_1", result.Data.Id);
            Assert.Equal(address.CountryCode, result.Data.CountryCode);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task CreateCustomerAddressAsync_WithInvalidCustomerId_ShouldThrowArgumentException(string customerId)
        {
            // Arrange
            Address address = new() { CountryCode = "TR" };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _service.CreateCustomerAddressAsync(customerId, address));
        }

        [Fact]
        public async Task CreateCustomerAddressAsync_WithNullAddress_ShouldThrowArgumentNullException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _service.CreateCustomerAddressAsync("ctm_1", null));
        }
    }
}