using System.Text.Json;

namespace PaddleWrapper.Entities.Shared
{
    public class ImportMeta
    {
        public string ExternalId { get; }
        public string ImportedFrom { get; }
        public string OriginalPurchaseDate { get; }
        public string OriginalCreatedAt { get; }
        public string OriginalAmount { get; }
        public string OriginalCurrency { get; }

        public ImportMeta(
            string externalId,
            string importedFrom,
            string originalPurchaseDate,
            string originalCreatedAt,
            string originalAmount,
            string originalCurrency)
        {
            ExternalId = externalId;
            ImportedFrom = importedFrom;
            OriginalPurchaseDate = originalPurchaseDate;
            OriginalCreatedAt = originalCreatedAt;
            OriginalAmount = originalAmount;
            OriginalCurrency = originalCurrency;
        }

        public static ImportMeta FromDict(JsonElement data)
        {
            return new ImportMeta(
                externalId: data.GetProperty("external_id").GetString(),
                importedFrom: data.GetProperty("imported_from").GetString(),
                originalPurchaseDate: data.GetProperty("original_purchase_date").GetString(),
                originalCreatedAt: data.GetProperty("original_created_at").GetString(),
                originalAmount: data.GetProperty("original_amount").GetString(),
                originalCurrency: data.GetProperty("original_currency").GetString()
            );
        }
    }
} 