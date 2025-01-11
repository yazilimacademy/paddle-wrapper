using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Shared;

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

    private TransactionPaymentAttempt(
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

    public static TransactionPaymentAttempt FromJson(JsonElement element)
    {
        return new TransactionPaymentAttempt(
            element.GetProperty("payment_attempt_id").GetString()!,
            element.TryGetProperty("payment_method_id", out var paymentMethodId) ? paymentMethodId.GetString() : null,
            element.GetProperty("stored_payment_method_id").GetString()!,
            element.GetProperty("amount").GetString()!,
            JsonSerializer.Deserialize<PaymentAttemptStatus>(element.GetProperty("status").GetRawText()),
            element.TryGetProperty("error_code", out var errorCode) ? JsonSerializer.Deserialize<ErrorCode>(errorCode.GetRawText()) : null,
            MethodDetails.FromJson(element.GetProperty("method_details")),
            DateTime.Parse(element.GetProperty("created_at").GetString()!),
            element.TryGetProperty("captured_at", out var capturedAt) ? DateTime.Parse(capturedAt.GetString()!) : null
        );
    }
} 