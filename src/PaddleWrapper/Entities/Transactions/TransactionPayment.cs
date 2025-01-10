using System.Text.Json;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Entities.Transactions
{
    public class TransactionPayment
    {
        public string Amount { get; }
        public string Status { get; }
        public DateTime CreatedAt { get; }
        public DateTime? CapturedAt { get; }
        public PaymentMethodDetails PaymentMethodDetails { get; }
        public string PaymentAttemptId { get; }
        public string StoredPaymentMethodId { get; }

        public TransactionPayment(
            string amount,
            string status,
            DateTime createdAt,
            DateTime? capturedAt,
            PaymentMethodDetails paymentMethodDetails,
            string paymentAttemptId,
            string storedPaymentMethodId)
        {
            Amount = amount;
            Status = status;
            CreatedAt = createdAt;
            CapturedAt = capturedAt;
            PaymentMethodDetails = paymentMethodDetails;
            PaymentAttemptId = paymentAttemptId;
            StoredPaymentMethodId = storedPaymentMethodId;
        }

        public static TransactionPayment FromDict(JsonElement data)
        {
            return new TransactionPayment(
                amount: data.GetProperty("amount").GetString(),
                status: data.GetProperty("status").GetString(),
                createdAt: DateTime.Parse(data.GetProperty("created_at").GetString()),
                capturedAt: data.TryGetProperty("captured_at", out var capturedAt) ? 
                    DateTime.Parse(capturedAt.GetString()) : null,
                paymentMethodDetails: PaymentMethodDetails.FromDict(data.GetProperty("payment_method_details")),
                paymentAttemptId: data.GetProperty("payment_attempt_id").GetString(),
                storedPaymentMethodId: data.TryGetProperty("stored_payment_method_id", out var methodId) ? 
                    methodId.GetString() : null
            );
        }
    }
} 