using Microsoft.Extensions.Logging;
using Moq;
using PaddleWrapper.Interfaces;
using PaddleWrapper.Models.Common;
using PaddleWrapper.Models.Transactions;
using PaddleWrapper.Services;

namespace PaddleWrapper.Tests.Services
{
    public class TransactionServiceTests
    {
        private readonly Mock<IPaddleClient> _mockClient;
        private readonly Mock<ILogger<TransactionService>> _mockLogger;
        private readonly TransactionService _service;

        public TransactionServiceTests()
        {
            _mockClient = new Mock<IPaddleClient>();
            _mockLogger = new Mock<ILogger<TransactionService>>();
            _service = new TransactionService(_mockClient.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task ListTransactionsAsync_ShouldReturnTransactions()
        {
            // Arrange
            PaddleResponse<List<Transaction>> expectedResponse = new()
            {
                Data = new List<Transaction>
                {
                    new() { Id = "txn_1", CustomerId = "ctm_1" },
                    new() { Id = "txn_2", CustomerId = "ctm_2" }
                }
            };

            _mockClient
                .Setup(x => x.GetAsync<PaddleResponse<List<Transaction>>>("/transactions", It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            PaddleResponse<List<Transaction>> result = await _service.ListTransactionsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Data.Count);
            Assert.Equal("txn_1", result.Data[0].Id);
            Assert.Equal("txn_2", result.Data[1].Id);
        }

        [Fact]
        public async Task GetTransactionAsync_WithValidId_ShouldReturnTransaction()
        {
            // Arrange
            string transactionId = "txn_1";
            PaddleResponse<Transaction> expectedResponse = new()
            {
                Data = new Transaction { Id = transactionId, CustomerId = "ctm_1" }
            };

            _mockClient
                .Setup(x => x.GetAsync<PaddleResponse<Transaction>>($"/transactions/{transactionId}", It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            PaddleResponse<Transaction> result = await _service.GetTransactionAsync(transactionId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(transactionId, result.Data.Id);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task GetTransactionAsync_WithInvalidId_ShouldThrowArgumentException(string transactionId)
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _service.GetTransactionAsync(transactionId));
        }

        [Fact]
        public async Task CreateTransactionAsync_WithValidTransaction_ShouldReturnCreatedTransaction()
        {
            // Arrange
            Transaction transaction = new() { CustomerId = "ctm_1" };
            PaddleResponse<Transaction> expectedResponse = new()
            {
                Data = new Transaction { Id = "txn_1", CustomerId = "ctm_1" }
            };

            _mockClient
                .Setup(x => x.PostAsync<Transaction, PaddleResponse<Transaction>>("/transactions", transaction, It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            PaddleResponse<Transaction> result = await _service.CreateTransactionAsync(transaction);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("txn_1", result.Data.Id);
            Assert.Equal(transaction.CustomerId, result.Data.CustomerId);
        }

        [Fact]
        public async Task CreateTransactionAsync_WithNullTransaction_ShouldThrowArgumentNullException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _service.CreateTransactionAsync(null));
        }

        [Fact]
        public async Task UpdateTransactionAsync_WithValidTransaction_ShouldReturnUpdatedTransaction()
        {
            // Arrange
            string transactionId = "txn_1";
            Transaction transaction = new() { CustomerId = "ctm_1" };
            PaddleResponse<Transaction> expectedResponse = new()
            {
                Data = new Transaction { Id = transactionId, CustomerId = "ctm_1" }
            };

            _mockClient
                .Setup(x => x.PatchAsync<Transaction, PaddleResponse<Transaction>>($"/transactions/{transactionId}", transaction, It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            PaddleResponse<Transaction> result = await _service.UpdateTransactionAsync(transactionId, transaction);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(transactionId, result.Data.Id);
            Assert.Equal(transaction.CustomerId, result.Data.CustomerId);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task UpdateTransactionAsync_WithInvalidId_ShouldThrowArgumentException(string transactionId)
        {
            // Arrange
            Transaction transaction = new() { CustomerId = "ctm_1" };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _service.UpdateTransactionAsync(transactionId, transaction));
        }

        [Fact]
        public async Task UpdateTransactionAsync_WithNullTransaction_ShouldThrowArgumentNullException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _service.UpdateTransactionAsync("txn_1", null));
        }

        [Fact]
        public async Task ListCustomerTransactionsAsync_WithValidCustomerId_ShouldReturnTransactions()
        {
            // Arrange
            string customerId = "ctm_1";
            PaddleResponse<List<Transaction>> expectedResponse = new()
            {
                Data = new List<Transaction>
                {
                    new() { Id = "txn_1", CustomerId = customerId },
                    new() { Id = "txn_2", CustomerId = customerId }
                }
            };

            _mockClient
                .Setup(x => x.GetAsync<PaddleResponse<List<Transaction>>>($"/transactions?customer_id={customerId}", It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            PaddleResponse<List<Transaction>> result = await _service.ListCustomerTransactionsAsync(customerId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Data.Count);
            Assert.All(result.Data, txn => Assert.Equal(customerId, txn.CustomerId));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ListCustomerTransactionsAsync_WithInvalidCustomerId_ShouldThrowArgumentException(string customerId)
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _service.ListCustomerTransactionsAsync(customerId));
        }

        [Fact]
        public async Task ListSubscriptionTransactionsAsync_WithValidSubscriptionId_ShouldReturnTransactions()
        {
            // Arrange
            string subscriptionId = "sub_1";
            PaddleResponse<List<Transaction>> expectedResponse = new()
            {
                Data = new List<Transaction>
                {
                    new() { Id = "txn_1", SubscriptionId = subscriptionId },
                    new() { Id = "txn_2", SubscriptionId = subscriptionId }
                }
            };

            _mockClient
                .Setup(x => x.GetAsync<PaddleResponse<List<Transaction>>>($"/transactions?subscription_id={subscriptionId}", It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            PaddleResponse<List<Transaction>> result = await _service.ListSubscriptionTransactionsAsync(subscriptionId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Data.Count);
            Assert.All(result.Data, txn => Assert.Equal(subscriptionId, txn.SubscriptionId));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ListSubscriptionTransactionsAsync_WithInvalidSubscriptionId_ShouldThrowArgumentException(string subscriptionId)
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _service.ListSubscriptionTransactionsAsync(subscriptionId));
        }

        [Fact]
        public async Task PreviewTransactionAsync_WithValidTransaction_ShouldReturnPreviewedTransaction()
        {
            // Arrange
            Transaction transaction = new() { CustomerId = "ctm_1" };
            PaddleResponse<Transaction> expectedResponse = new()
            {
                Data = new Transaction { Id = "txn_1", CustomerId = "ctm_1", Status = "preview" }
            };

            _mockClient
                .Setup(x => x.PostAsync<Transaction, PaddleResponse<Transaction>>("/transactions/preview", transaction, It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            PaddleResponse<Transaction> result = await _service.PreviewTransactionAsync(transaction);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("preview", result.Data.Status);
        }

        [Fact]
        public async Task PreviewTransactionAsync_WithNullTransaction_ShouldThrowArgumentNullException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _service.PreviewTransactionAsync(null));
        }

        [Fact]
        public async Task InvoiceTransactionAsync_WithValidId_ShouldReturnInvoicedTransaction()
        {
            // Arrange
            string transactionId = "txn_1";
            PaddleResponse<Transaction> expectedResponse = new()
            {
                Data = new Transaction { Id = transactionId, Status = "invoiced" }
            };

            _mockClient
                .Setup(x => x.PostAsync<object, PaddleResponse<Transaction>>($"/transactions/{transactionId}/invoice", null, It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            PaddleResponse<Transaction> result = await _service.InvoiceTransactionAsync(transactionId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("invoiced", result.Data.Status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task InvoiceTransactionAsync_WithInvalidId_ShouldThrowArgumentException(string transactionId)
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _service.InvoiceTransactionAsync(transactionId));
        }
    }
}