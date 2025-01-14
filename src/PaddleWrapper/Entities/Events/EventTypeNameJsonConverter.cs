using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Events;

public class EventTypeNameJsonConverter : JsonConverter<EventTypeName>
{
    public override EventTypeName Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString();
        if (value == null)
        {
            throw new JsonException("Event type cannot be null");
        }

        foreach (EventTypeName eventType in Enum.GetValues<EventTypeName>())
        {
            var enumMemberAttribute = typeToConvert
                .GetField(eventType.ToString())
                ?.GetCustomAttributes(false)
                .OfType<System.Runtime.Serialization.EnumMemberAttribute>()
                .FirstOrDefault();

            if (enumMemberAttribute?.Value == value)
            {
                return eventType;
            }
        }

        throw new JsonException($"Invalid event type: {value}");
    }

    public override void Write(Utf8JsonWriter writer, EventTypeName value, JsonSerializerOptions options)
    {
        var enumMemberAttribute = value.GetType()
            .GetField(value.ToString())
            ?.GetCustomAttributes(false)
            .OfType<System.Runtime.Serialization.EnumMemberAttribute>()
            .FirstOrDefault();

        string stringValue = enumMemberAttribute?.Value ?? value.ToString();
        writer.WriteStringValue(stringValue);
    }
} 