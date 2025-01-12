using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Resources.Discounts.Operations;

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
            var response = await _client.GetRaw("/discounts", listOperation);
            ResponseParser parser = new(response);

            return DiscountCollection.From(
                parser.GetData(),
                new Paginator(_client, parser.GetPagination(), typeof(DiscountCollection))
            );
        }

        public async Task<Discount> GetAsync(string id)
        {
            HttpResponseMessage response = await _client.GetRaw($"/discounts/{id}");
            ResponseParser parser = new(response);

            return Discount.From(parser.GetData());
        }

        public async Task<Discount> CreateAsync(CreateDiscount createOperation)
        {
            var response = await _client.PostRawAsync("/discounts", createOperation);
            ResponseParser parser = new(response);

            return Discount.From(parser.GetData());
        }

        public async Task<Discount> UpdateAsync(string id, UpdateDiscount operation)
        {
            var response = await _client.PatchRawAsync($"/discounts/{id}", operation);
            ResponseParser parser = new(response);

            return Discount.From(parser.GetData());
        }

        public async Task<Discount> ArchiveAsync(string id)
        {
            return await UpdateAsync(id, new UpdateDiscount { Status = DiscountStatus.Archived });
        }
    }
}