using System.Threading.Tasks;
using PaddleWrapper.Client;
using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Discount;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Resources.Discounts.Operations;

namespace PaddleWrapper.Resources.Discounts
{
    public class DiscountsClient
    {
        private readonly IPaddleClient _client;

        public DiscountsClient(IPaddleClient client)
        {
            _client = client;
        }

        public async Task<DiscountCollection> ListAsync(ListDiscounts listOperation = null)
        {
            listOperation ??= new ListDiscounts();
            var response = await _client.GetRawAsync("/discounts", listOperation);
            var parser = new ResponseParser(response);

            return DiscountCollection.From(
                parser.GetData(),
                new Paginator(_client, parser.GetPagination(), typeof(DiscountCollection))
            );
        }

        public async Task<Discount> GetAsync(string id)
        {
            var response = await _client.GetRawAsync($"/discounts/{id}");
            var parser = new ResponseParser(response);

            return Discount.From(parser.GetData());
        }

        public async Task<Discount> CreateAsync(CreateDiscount createOperation)
        {
            var response = await _client.PostRawAsync("/discounts", createOperation);
            var parser = new ResponseParser(response);

            return Discount.From(parser.GetData());
        }

        public async Task<Discount> UpdateAsync(string id, UpdateDiscount operation)
        {
            var response = await _client.PatchRawAsync($"/discounts/{id}", operation);
            var parser = new ResponseParser(response);

            return Discount.From(parser.GetData());
        }

        public async Task<Discount> ArchiveAsync(string id)
        {
            return await UpdateAsync(id, new UpdateDiscount { Status = DiscountStatus.Archived });
        }
    }
} 