using System.Threading.Tasks;
using PaddleWrapper.Core.Interfaces;
using PaddleWrapper.Core.Models;
using PaddleWrapper.Core.Models.Payment;

namespace PaddleWrapper.Core.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly PaddleHttpClient _httpClient;
        private const string BaseEndpoint = "payment";

        public PaymentService(PaddleHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PaddleResponse<Payment>> GetPaymentAsync(string paymentId)
        {
            return await _httpClient.GetAsync<PaddleResponse<Payment>>($"{BaseEndpoint}/{paymentId}");
        }

        public async Task<PaddleResponse<Payment[]>> ListPaymentsAsync(int? userId = null)
        {
            var endpoint = userId.HasValue ? $"{BaseEndpoint}/user/{userId}" : BaseEndpoint;
            return await _httpClient.GetAsync<PaddleResponse<Payment[]>>(endpoint);
        }

        public async Task<PaddleResponse<string>> CreatePaymentUrlAsync(PaymentRequest request)
        {
            return await _httpClient.PostAsync<PaddleResponse<string>>($"{BaseEndpoint}/generate-url", request);
        }

        public async Task<PaddleResponse<Payment>> RefundPaymentAsync(string paymentId, decimal? amount = null)
        {
            var refundRequest = amount.HasValue ? new { amount } : null;
            return await _httpClient.PostAsync<PaddleResponse<Payment>>($"{BaseEndpoint}/{paymentId}/refund", refundRequest);
        }

        public async Task<PaddleResponse<Payment[]>> ListRefundsAsync(string paymentId)
        {
            return await _httpClient.GetAsync<PaddleResponse<Payment[]>>($"{BaseEndpoint}/{paymentId}/refunds");
        }
    }
} 