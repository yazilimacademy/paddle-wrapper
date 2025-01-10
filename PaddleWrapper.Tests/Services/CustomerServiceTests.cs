using System;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using PaddleWrapper.Core.Configuration;
using PaddleWrapper.Core.Interfaces;
using PaddleWrapper.Core.Models;
using PaddleWrapper.Core.Models.Customer;
using PaddleWrapper.Core.Services;
using PaddleWrapper.Core.Services.Customers;
using Xunit;

namespace PaddleWrapper.Tests.Services
{
    public class CustomerServiceTests
    {
        private readonly Mock<IPaddleLogger> _loggerMock;
        private readonly Mock<IOptions<PaddleOptions>> _optionsMock;
        private readonly PaddleOptions _options;

        public CustomerServiceTests()
        {
            _loggerMock = new Mock<IPaddleLogger>();
            _options = new PaddleOptions
            {
                ApiKey = "test_api_key",
                VendorId = "test_vendor_id"
            };
            _optionsMock = new Mock<IOptions<PaddleOptions>>();
            _optionsMock.Setup(x => x.Value).Returns(_options);
        }

        [Fact]
        public async Task GetCustomerAsync_ValidId_ReturnsCustomer()
        {
            // Arrange
            var expectedCustomer = new Customer 
            { 
                Id = "cus_123", 
                Email = "test@example.com",
                Name = "Test Customer"
            };
            var expectedResponse = new PaddleResponse<Customer> { Success = true, Response = expectedCustomer };

            var httpClient = new HttpClient(new MockHttpMessageHandler(expectedResponse));
            var paddleHttpClient = new PaddleHttpClient(httpClient, _optionsMock.Object, _loggerMock.Object);
            var customerService = new CustomerService(paddleHttpClient);

            // Act
            var result = await customerService.GetCustomerAsync("cus_123");

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Response.Should().NotBeNull();
            result.Response.Id.Should().Be("cus_123");
            result.Response.Email.Should().Be("test@example.com");
            result.Response.Name.Should().Be("Test Customer");
        }

        [Fact]
        public async Task CreateCustomerAsync_ValidCustomer_ReturnsCreatedCustomer()
        {
            // Arrange
            var newCustomer = new Customer 
            { 
                Email = "new@example.com",
                Name = "New Customer"
            };
            var expectedResponse = new PaddleResponse<Customer>
            {
                Success = true,
                Response = new Customer 
                { 
                    Id = "cus_123",
                    Email = "new@example.com",
                    Name = "New Customer"
                }
            };

            var httpClient = new HttpClient(new MockHttpMessageHandler(expectedResponse));
            var paddleHttpClient = new PaddleHttpClient(httpClient, _optionsMock.Object, _loggerMock.Object);
            var customerService = new CustomerService(paddleHttpClient);

            // Act
            var result = await customerService.CreateCustomerAsync(newCustomer);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Response.Should().NotBeNull();
            result.Response.Id.Should().Be("cus_123");
            result.Response.Email.Should().Be("new@example.com");
            result.Response.Name.Should().Be("New Customer");
        }

        [Fact]
        public async Task GetCustomerAddressesAsync_ValidCustomerId_ReturnsAddresses()
        {
            // Arrange
            var expectedAddresses = new[]
            {
                new Address { Id = "addr_123", CountryCode = "US" },
                new Address { Id = "addr_124", CountryCode = "GB" }
            };
            var expectedResponse = new PaddleResponse<Address[]> { Success = true, Response = expectedAddresses };

            var httpClient = new HttpClient(new MockHttpMessageHandler(expectedResponse));
            var paddleHttpClient = new PaddleHttpClient(httpClient, _optionsMock.Object, _loggerMock.Object);
            var customerService = new CustomerService(paddleHttpClient);

            // Act
            var result = await customerService.GetCustomerAddressesAsync("cus_123");

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Response.Should().NotBeNull();
            result.Response.Should().HaveCount(2);
            result.Response[0].Id.Should().Be("addr_123");
            result.Response[1].Id.Should().Be("addr_124");
        }

        [Fact]
        public async Task GetCustomerBusinessAsync_ValidCustomerId_ReturnsBusiness()
        {
            // Arrange
            var expectedBusiness = new Business 
            { 
                Id = "biz_123",
                Name = "Test Business",
                TaxNumber = "123456789"
            };
            var expectedResponse = new PaddleResponse<Business> { Success = true, Response = expectedBusiness };

            var httpClient = new HttpClient(new MockHttpMessageHandler(expectedResponse));
            var paddleHttpClient = new PaddleHttpClient(httpClient, _optionsMock.Object, _loggerMock.Object);
            var customerService = new CustomerService(paddleHttpClient);

            // Act
            var result = await customerService.GetCustomerBusinessAsync("cus_123");

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Response.Should().NotBeNull();
            result.Response.Id.Should().Be("biz_123");
            result.Response.Name.Should().Be("Test Business");
            result.Response.TaxNumber.Should().Be("123456789");
        }
    }
} 