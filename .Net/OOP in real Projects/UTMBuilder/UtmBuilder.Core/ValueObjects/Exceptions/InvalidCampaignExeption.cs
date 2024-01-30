namespace UtmBuilder.Core.ValueObjects.Exceptions
{
    public class InvalidCampaignExeption : Exception
    {
        private const string DefaultErrorMessage = "Invalid UTM parameters";
        public InvalidCampaignExeption(
    string message = DefaultErrorMessage) : base(message)
        {
        }

        public static void ThrowIfNull(
         string? item,
         string message = DefaultErrorMessage)
        {
            if (string.IsNullOrEmpty(item))
                throw new InvalidCampaignExeption(message);
        }
    }
}
