using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TaxCategory
    {
        [EnumMember(Value = "digital-goods")]
        DigitalGoods,

        [EnumMember(Value = "ebooks")]
        Ebooks,

        [EnumMember(Value = "implementation-services")]
        ImplementationServices,

        [EnumMember(Value = "professional-services")]
        ProfessionalServices,

        [EnumMember(Value = "saas")]
        Saas,

        [EnumMember(Value = "software-programming-services")]
        SoftwareProgrammingServices,

        [EnumMember(Value = "standard")]
        Standard,

        [EnumMember(Value = "training-services")]
        TrainingServices,

        [EnumMember(Value = "website-hosting")]
        WebsiteHosting
    }
} 