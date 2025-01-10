namespace PaddleWrapper.Exceptions.SdkExceptions
{
    public class InvalidArgumentException : SdkException
    {
        private InvalidArgumentException(string message) : base(message)
        {
        }

        public static InvalidArgumentException ArrayIsEmpty(string field)
        {
            string message = $"'{field}' cannot be empty";
            return new InvalidArgumentException(message);
        }

        public static InvalidArgumentException ArrayContainsInvalidTypes(string field, string[] expectedTypes, object[] given = null)
        {
            string message;
            if (expectedTypes.Length > 1)
            {
                string expectedTypesStr = string.Join("', '", expectedTypes);
                message = $"Expected '{field}' to only contain types '{expectedTypesStr}'";
            }
            else
            {
                message = $"Expected '{field}' to only contain type '{expectedTypes[0]}'";
            }

            if (given != null)
            {
                string invalidTypeList = string.Join("', '", given.Select(x => x.GetType().Name));
                message += $" ('{invalidTypeList}' given)";
            }

            return new InvalidArgumentException(message);
        }

        public static InvalidArgumentException ArrayContainsInvalidTypes(string field, string expectedType, object[] given = null)
        {
            return ArrayContainsInvalidTypes(field, new[] { expectedType }, given);
        }
    }
}