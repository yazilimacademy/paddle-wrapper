using System.Runtime.Serialization;

namespace PaddleWrapper.Resources.Subscriptions.Operations.Get
{
    public enum Includes
    {
        [EnumMember(Value = "next_transaction")]
        NextTransaction,

        [EnumMember(Value = "recurring_transaction_details")]
        RecurringTransactionDetails
    }
}