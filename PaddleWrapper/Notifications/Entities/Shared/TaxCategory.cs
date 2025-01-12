using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Shared;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TaxCategory
{
    [JsonPropertyName("digital-goods")]
    DigitalGoods,
    [JsonPropertyName("ebooks")]
    Ebooks,
    [JsonPropertyName("implementation-services")]
    ImplementationServices,
    [JsonPropertyName("professional-services")]
    ProfessionalServices,
    [JsonPropertyName("saas")]
    Saas,
    [JsonPropertyName("software-programming-services")]
    SoftwareProgrammingServices,
    [JsonPropertyName("standard")]
    Standard,
    [JsonPropertyName("training-services")]
    TrainingServices,
    [JsonPropertyName("website-hosting")]
    WebsiteHosting
}