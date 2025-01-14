using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TaxMode
    {
        [EnumMember(Value = "account_setting")]
        AccountSetting,

        [EnumMember(Value = "external")]
        External,

        [EnumMember(Value = "internal")]
        Internal
    }
}