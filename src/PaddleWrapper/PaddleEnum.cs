using System.Reflection;
using System.Text.Json;

namespace PaddleWrapper;

public abstract class PaddleEnum
{
    protected readonly string Value;

    protected PaddleEnum(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }

    public static T FromJson<T>(JsonElement element) where T : Enum
    {
        return JsonSerializer.Deserialize<T>(element.GetRawText());
    }

    protected static T FromString<T>(string value) where T : PaddleEnum
    {
        Type type = typeof(T);
        IEnumerable<FieldInfo> fields = type.GetFields(BindingFlags.Public | BindingFlags.Static)
            .Where(f => f.FieldType == type);

        foreach (FieldInfo? field in fields)
        {
            T? enumValue = (T)field.GetValue(null);
            if (enumValue.ToString().Equals(value, StringComparison.OrdinalIgnoreCase))
            {
                return enumValue;
            }
        }

        throw new ArgumentException($"No matching value found in {type.Name} for '{value}'");
    }
}