using System.Threading.Tasks;
using PaddleWrapper.Core.Models;
using PaddleWrapper.Core.Models.Payment;

namespace PaddleWrapper.Core.Interfaces
{
    public interface IPaymentService
    {
        Task<PaddleResponse<Payment>> GetPaymentAsync(string paymentId);
        Task<PaddleResponse<Payment[]>> ListPaymentsAsync(int? userId = null);
        Task<PaddleResponse<string>> CreatePaymentUrlAsync(PaymentRequest request);
        Task<PaddleResponse<Payment>> RefundPaymentAsync(string paymentId, decimal? amount = null);
        Task<PaddleResponse<Payment[]>> ListRefundsAsync(string paymentId);
    }
} 