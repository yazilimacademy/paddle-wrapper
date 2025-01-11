using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Events
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EventTypeName
    {
        [EnumMember(Value = "address.created")]
        AddressCreated,

        [EnumMember(Value = "address.imported")]
        AddressImported,

        [EnumMember(Value = "address.updated")]
        AddressUpdated,

        [EnumMember(Value = "adjustment.created")]
        AdjustmentCreated,

        [EnumMember(Value = "adjustment.updated")]
        AdjustmentUpdated,

        [EnumMember(Value = "business.created")]
        BusinessCreated,

        [EnumMember(Value = "business.imported")]
        BusinessImported,

        [EnumMember(Value = "business.updated")]
        BusinessUpdated,

        [EnumMember(Value = "customer.created")]
        CustomerCreated,

        [EnumMember(Value = "customer.imported")]
        CustomerImported,

        [EnumMember(Value = "customer.updated")]
        CustomerUpdated,

        [EnumMember(Value = "discount.created")]
        DiscountCreated,

        [EnumMember(Value = "discount.imported")]
        DiscountImported,

        [EnumMember(Value = "discount.updated")]
        DiscountUpdated,

        [EnumMember(Value = "invoice.canceled")]
        InvoiceCanceled,

        [EnumMember(Value = "invoice.created")]
        InvoiceCreated,

        [EnumMember(Value = "invoice.issued")]
        InvoiceIssued,

        [EnumMember(Value = "invoice.overdue")]
        InvoiceOverdue,

        [EnumMember(Value = "invoice.paid")]
        InvoicePaid,

        [EnumMember(Value = "invoice.scheduled")]
        InvoiceScheduled,

        [EnumMember(Value = "payout.created")]
        PayoutCreated,

        [EnumMember(Value = "payout.paid")]
        PayoutPaid,

        [EnumMember(Value = "price.created")]
        PriceCreated,

        [EnumMember(Value = "price.updated")]
        PriceUpdated,

        [EnumMember(Value = "price.imported")]
        PriceImported,

        [EnumMember(Value = "product.created")]
        ProductCreated,

        [EnumMember(Value = "product.updated")]
        ProductUpdated,

        [EnumMember(Value = "product.imported")]
        ProductImported,

        [EnumMember(Value = "subscription.activated")]
        SubscriptionActivated,

        [EnumMember(Value = "subscription.canceled")]
        SubscriptionCanceled,

        [EnumMember(Value = "subscription.created")]
        SubscriptionCreated,

        [EnumMember(Value = "subscription.imported")]
        SubscriptionImported,

        [EnumMember(Value = "subscription.past_due")]
        SubscriptionPastDue,

        [EnumMember(Value = "subscription.paused")]
        SubscriptionPaused,

        [EnumMember(Value = "subscription.resumed")]
        SubscriptionResumed,

        [EnumMember(Value = "subscription.trialing")]
        SubscriptionTrialing,

        [EnumMember(Value = "subscription.updated")]
        SubscriptionUpdated,

        [EnumMember(Value = "transaction.billed")]
        TransactionBilled,

        [EnumMember(Value = "transaction.canceled")]
        TransactionCanceled,

        [EnumMember(Value = "transaction.completed")]
        TransactionCompleted,

        [EnumMember(Value = "transaction.created")]
        TransactionCreated,

        [EnumMember(Value = "transaction.paid")]
        TransactionPaid,

        [EnumMember(Value = "transaction.past_due")]
        TransactionPastDue,

        [EnumMember(Value = "transaction.payment_failed")]
        TransactionPaymentFailed,

        [EnumMember(Value = "transaction.ready")]
        TransactionReady,

        [EnumMember(Value = "transaction.updated")]
        TransactionUpdated,

        [EnumMember(Value = "report.created")]
        ReportCreated,

        [EnumMember(Value = "report.updated")]
        ReportUpdated
    }
}