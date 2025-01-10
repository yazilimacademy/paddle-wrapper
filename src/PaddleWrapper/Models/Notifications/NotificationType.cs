using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace PaddleWrapper.Models.Notifications
{
    /// <summary>
    /// Represents the type of notification
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum NotificationType
    {
        /// <summary>
        /// A subscription was created
        /// </summary>
        [EnumMember(Value = "subscription.created")]
        SubscriptionCreated,

        /// <summary>
        /// A subscription was updated
        /// </summary>
        [EnumMember(Value = "subscription.updated")]
        SubscriptionUpdated,

        /// <summary>
        /// A subscription was canceled
        /// </summary>
        [EnumMember(Value = "subscription.canceled")]
        SubscriptionCanceled,

        /// <summary>
        /// A transaction was created
        /// </summary>
        [EnumMember(Value = "transaction.created")]
        TransactionCreated,

        /// <summary>
        /// A transaction was completed
        /// </summary>
        [EnumMember(Value = "transaction.completed")]
        TransactionCompleted,

        /// <summary>
        /// A transaction failed
        /// </summary>
        [EnumMember(Value = "transaction.failed")]
        TransactionFailed,

        /// <summary>
        /// A customer was created
        /// </summary>
        [EnumMember(Value = "customer.created")]
        CustomerCreated,

        /// <summary>
        /// A customer was updated
        /// </summary>
        [EnumMember(Value = "customer.updated")]
        CustomerUpdated,

        /// <summary>
        /// A product was created
        /// </summary>
        [EnumMember(Value = "product.created")]
        ProductCreated,

        /// <summary>
        /// A product was updated
        /// </summary>
        [EnumMember(Value = "product.updated")]
        ProductUpdated,

        /// <summary>
        /// A price was created
        /// </summary>
        [EnumMember(Value = "price.created")]
        PriceCreated,

        /// <summary>
        /// A price was updated
        /// </summary>
        [EnumMember(Value = "price.updated")]
        PriceUpdated
    }
}