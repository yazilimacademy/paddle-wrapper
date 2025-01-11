using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    public class TransactionPaymentAttempt
    {
        [JsonPropertyName("payment_attempt_id")]
        public string PaymentAttemptId { get; }

        [JsonPropertyName("payment_method_id")]
        public string? PaymentMethodId { get; }

        [JsonPropertyName("stored_payment_method_id")]
        [Obsolete("This property is deprecated")]
        public string StoredPaymentMethodId { get; }

        [JsonPropertyName("amount")]
        public string Amount { get; }

        [JsonPropertyName("status")]
        public PaymentAttemptStatus Status { get; }

        [JsonPropertyName("error_code")]
        public ErrorCode? ErrorCode { get; }

        [JsonPropertyName("method_details")]
        public MethodDetails MethodDetails { get; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; }

        [JsonPropertyName("captured_at")]
        public DateTime? CapturedAt { get; }

        [JsonConstructor]
        public TransactionPaymentAttempt(
            string paymentAttemptId,
            string? paymentMethodId,
            string storedPaymentMethodId,
            string amount,
            PaymentAttemptStatus status,
            ErrorCode? errorCode,
            MethodDetails methodDetails,
            DateTime createdAt,
            DateTime? capturedAt)
        {
            PaymentAttemptId = paymentAttemptId;
            PaymentMethodId = paymentMethodId;
            StoredPaymentMethodId = storedPaymentMethodId;
            Amount = amount;
            Status = status;
            ErrorCode = errorCode;
            MethodDetails = methodDetails;
            CreatedAt = createdAt;
            CapturedAt = capturedAt;
        }

        public static TransactionPaymentAttempt From(Dictionary<string, object> data)
        {
            return new TransactionPaymentAttempt(
                paymentAttemptId: data["payment_attempt_id"].ToString(),
                paymentMethodId: data.ContainsKey("payment_method_id") ? data["payment_method_id"]?.ToString() : null,
                storedPaymentMethodId: data["stored_payment_method_id"].ToString(),
                amount: data["amount"].ToString(),
                status: Enum.Parse<PaymentAttemptStatus>(data["status"].ToString(), true),
                errorCode: data.ContainsKey("error_code") && data["error_code"] != null
                    ? Enum.Parse<ErrorCode>(data["error_code"].ToString(), true)
                    : null,
                methodDetails: MethodDetails.From((Dictionary<string, object>)data["method_details"]),
                createdAt: DateTime.Parse(data["created_at"].ToString()),
                capturedAt: data.ContainsKey("captured_at") && data["captured_at"] != null
                    ? DateTime.Parse(data["captured_at"].ToString())
                    : null
            );
        }
    }
} 