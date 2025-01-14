namespace PaddleWrapper.Security;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter | AttributeTargets.Field)]
public sealed class SensitiveDataAttribute : Attribute
{
}