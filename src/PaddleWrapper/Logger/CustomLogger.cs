using System.Text.RegularExpressions;

namespace PaddleWrapper.Logger
{
    public class CustomLogger
    {
        private static readonly Dictionary<string, string> SearchPatterns = new()
        {
            { @"'X-Transaction-ID': '\s*([^']+)'", "'X-Transaction-ID': '<redacted>'" },
            { @"Bearer \s*([^']+)", "Bearer <API_SECRET_KEY>" }
        };

        public static string FilterSensitiveData(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return message;
            }

            string filteredMessage = message;
            foreach (KeyValuePair<string, string> pattern in SearchPatterns)
            {
                filteredMessage = Regex.Replace(filteredMessage, pattern.Key, pattern.Value);
            }

            return filteredMessage;
        }
    }
}