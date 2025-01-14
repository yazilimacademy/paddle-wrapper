using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Exceptions.ApiErrors;
using PaddleWrapper.Exceptions.SdkExceptions;
using PaddleWrapper.Extensions;
using PaddleWrapper.Resources.Transactions.Operations;
using PaddleWrapper.Resources.Transactions.Operations.List;
using System.Text.Json;

namespace PaddleWrapper.Resources.Transactions;

public class TransactionsClient
{
    private readonly Client _client;

    public TransactionsClient(Client client)
    {
        _client = client;
    }

    public async Task<TransactionCollection> ListAsync(ListTransactions listOperation = null)
    {
        try
        {
            listOperation ??= new ListTransactions();
            HttpResponseMessage response = await _client.GetRawAsync("/transactions", listOperation);
            string jsonString = await response.Content.ReadAsStringAsync();
            JsonElement jsonElement = JsonDocument.Parse(jsonString).RootElement;

            if (!response.IsSuccessStatusCode)
            {
                throw TransactionApiError.FromJson(jsonElement);
            }

            JsonElement data = jsonElement.GetProperty("data");
            JsonElement meta = jsonElement.GetProperty("meta");

            Paginator paginator = new(
                _client.HttpClient,
                Pagination.FromJson(meta),
                typeof(TransactionCollection)
            );

            return TransactionCollection.FromJson(data, paginator);
        }
        catch (JsonException ex)
        {
            throw new MalformedResponse("Failed to parse API response", ex);
        }
        catch (TransactionApiError)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new SdkException("An unexpected error occurred", ex);
        }
    }

    public async Task<Transaction> GetAsync(string id, Includes[] includes = null)
    {
        try
        {
            includes ??= Array.Empty<Includes>();
            var parameters = includes.Length == 0
                ? null
                : new { include = string.Join(",", includes.Select(x => x.ToString())) };

            HttpResponseMessage response = await _client.GetRawAsync($"/transactions/{id}", parameters);
            string jsonString = await response.Content.ReadAsStringAsync();
            JsonElement root = JsonDocument.Parse(jsonString).RootElement;

            if (!response.IsSuccessStatusCode)
            {
                throw TransactionApiError.FromJson(root);
            }

            return Transaction.FromJson(root.GetProperty("data"));
        }
        catch (JsonException ex)
        {
            throw new MalformedResponse("Failed to parse API response", ex);
        }
        catch (TransactionApiError)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new SdkException("An unexpected error occurred", ex);
        }
    }

    public async Task<Transaction> CreateAsync(CreateTransaction createOperation, Includes[] includes = null)
    {
        try
        {
            includes ??= Array.Empty<Includes>();
            var parameters = includes.Length == 0
                ? null
                : new { include = string.Join(",", includes.Select(x => x.ToString())) };

            HttpResponseMessage response = await _client.PostRawAsync("/transactions", createOperation, parameters);
            string jsonString = await response.Content.ReadAsStringAsync();
            JsonElement root = JsonDocument.Parse(jsonString).RootElement;

            if (!response.IsSuccessStatusCode)
            {
                throw TransactionApiError.FromJson(root);
            }

            return Transaction.FromJson(root.GetProperty("data"));
        }
        catch (JsonException ex)
        {
            throw new MalformedResponse("Failed to parse API response", ex);
        }
        catch (TransactionApiError)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new SdkException("An unexpected error occurred", ex);
        }
    }

    public async Task<Transaction> UpdateAsync(string id, UpdateTransaction operation)
    {
        try
        {
            HttpResponseMessage response = await _client.PatchRawAsync($"/transactions/{id}", operation);
            string jsonString = await response.Content.ReadAsStringAsync();
            JsonElement root = JsonDocument.Parse(jsonString).RootElement;

            if (!response.IsSuccessStatusCode)
            {
                throw TransactionApiError.FromJson(root);
            }

            return Transaction.FromJson(root.GetProperty("data"));
        }
        catch (JsonException ex)
        {
            throw new MalformedResponse("Failed to parse API response", ex);
        }
        catch (TransactionApiError)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new SdkException("An unexpected error occurred", ex);
        }
    }

    public async Task<TransactionPreview> PreviewAsync(PreviewTransaction operation)
    {
        try
        {
            HttpResponseMessage response = await _client.PostRawAsync("/transactions/preview", operation);
            string jsonString = await response.Content.ReadAsStringAsync();
            JsonElement root = JsonDocument.Parse(jsonString).RootElement;

            if (!response.IsSuccessStatusCode)
            {
                throw TransactionApiError.FromJson(root);
            }

            return TransactionPreview.FromJson(root.GetProperty("data"));
        }
        catch (JsonException ex)
        {
            throw new MalformedResponse("Failed to parse API response", ex);
        }
        catch (TransactionApiError)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new SdkException("An unexpected error occurred", ex);
        }
    }

    public async Task<TransactionData> GetInvoicePdfAsync(string id, GetTransactionInvoice getOperation = null)
    {
        try
        {
            getOperation ??= new GetTransactionInvoice();
            HttpResponseMessage response = await _client.GetRawAsync($"/transactions/{id}/invoice", getOperation);
            string jsonString = await response.Content.ReadAsStringAsync();
            JsonElement root = JsonDocument.Parse(jsonString).RootElement;

            if (!response.IsSuccessStatusCode)
            {
                throw TransactionApiError.FromJson(root);
            }

            return TransactionData.FromJson(root.GetProperty("data"));
        }
        catch (JsonException ex)
        {
            throw new MalformedResponse("Failed to parse API response", ex);
        }
        catch (TransactionApiError)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new SdkException("An unexpected error occurred", ex);
        }
    }
}