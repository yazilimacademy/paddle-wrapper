using PaddleWrapper.Security;

namespace PaddleWrapper.Notifications;

public sealed class Secret
{
    [SensitiveData]
    public string Key { get; }

    public Secret([SensitiveData] string key)
    {
        Key = key;
    }
}