using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Extensions;
using PaddleWrapper.Notifications.Entities.Discounts;
using PaddleWrapper.Resources.Discounts.Operations;
using System.Text.Json;

namespace PaddleWrapper.Resources.Discounts
{
    public class DiscountsClient
    {
        private readonly Client _client;

        public DiscountsClient(Client client)
        {
            _client = client;
        }

        public async Task<DiscountCollection> ListAsync(ListDiscounts listOperation = null)
        {
            listOperation ??= new ListDiscounts();
            HttpResponseMessage response = await _client.GetRawAsync("/discounts", listOperation);
            JsonElement jsonElement = JsonDocument.Parse(await response.Content.ReadAsStringAsync()).RootElement;
            JsonElement data = jsonElement.GetProperty("data");
            JsonElement meta = jsonElement.GetProperty("meta");

            Paginator paginator = new(
                _client.HttpClient,
                Pagination.FromJson(meta),
                typeof(DiscountCollection)
            );

            return DiscountCollection.FromJson(data, paginator);
        }

        public async Task<Discount> GetAsync(string id)
        {
            JsonDocument response = await _client.Get($"/discounts/{id}");
            return Discount.FromJson(response.RootElement.GetProperty("data"));
        }

        public async Task<Discount> CreateAsync(CreateDiscount createOperation)
        {
            JsonDocument response = await _client.Post("/discounts", createOperation);
            return Discount.FromJson(response.RootElement.GetProperty("data"));
        }

        public async Task<Discount> UpdateAsync(string id, UpdateDiscount operation)
        {
            JsonDocument response = await _client.Patch($"/discounts/{id}", operation);
            return Discount.FromJson(response.RootElement.GetProperty("data"));
        }

        public async Task<Discount> ArchiveAsync(string id)
        {
            return await UpdateAsync(id, new UpdateDiscount { Status = DiscountStatus.Archived });
        }
    }
}