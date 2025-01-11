using System;
using System.Linq;
using System.Reflection;

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

    protected static T FromString<T>(string value) where T : PaddleEnum
    {
        var type = typeof(T);
        var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static)
            .Where(f => f.FieldType == type);

        foreach (var field in fields)
        {
            var enumValue = (T)field.GetValue(null);
            if (enumValue.ToString().Equals(value, StringComparison.OrdinalIgnoreCase))
            {
                return enumValue;
            }
        }

        throw new ArgumentException($"No matching value found in {type.Name} for '{value}'");
    }
} 