using System.Runtime.Serialization;

namespace PaddleWrapper.Resources.Transactions.Operations.List
{
    public enum Includes
    {
        [EnumMember(Value = "address")]
        Address,

        [EnumMember(Value = "adjustment")]
        Adjustment,

        [EnumMember(Value = "adjustments_totals")]
        AdjustmentsTotals,

        [EnumMember(Value = "available_payment_methods")]
        AvailablePaymentMethods,

        [EnumMember(Value = "business")]
        Business,

        [EnumMember(Value = "customer")]
        Customer,

        [EnumMember(Value = "discount")]
        Discount
    }
} 