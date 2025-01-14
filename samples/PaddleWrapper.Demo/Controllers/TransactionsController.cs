using Microsoft.AspNetCore.Mvc;
using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Exceptions.ApiErrors;
using PaddleWrapper.Exceptions.SdkExceptions;
using PaddleWrapper.Resources.Transactions.Operations;

namespace PaddleWrapper.Demo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionsController(Client client) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<TransactionCollection>> GetTransactions([FromQuery] int? page, [FromQuery] int? perPage)
    {
        try
        {
            ListTransactions listOperation = new()
            {
                Page = page,
                PerPage = perPage ?? 10,
                OrderBy = "id:asc"
            };

            TransactionCollection transactions = await client.Transactions.ListAsync(listOperation);
            return Ok(transactions);
        }
        catch (TransactionApiError ex)
        {
            return StatusCode(500, new
            {
                code = ex.Code,
                type = ex.Type,
                detail = ex.Detail,
                error = "Transaction API Error",
                documentationUrl = ex.DocumentationUrl,
                fieldErrors = ex.FieldErrors?.Select(fe => new
                {
                    code = fe.Code,
                    field = fe.Field,
                    message = fe.Message
                })
            });
        }
        catch (ApiError ex)
        {
            return StatusCode(500, new
            {
                error = "API Error",
                code = ex.Code,
                type = ex.Type,
                detail = ex.Detail,
                documentationUrl = ex.DocumentationUrl
            });
        }
        catch (MalformedResponse ex)
        {
            return StatusCode(500, new
            {
                message = ex.Message,
                error = "Malformed Response Error",
                innerException = ex.InnerException?.Message
            });
        }
        catch (SdkException ex)
        {
            return StatusCode(500, new { error = $"SDK Error: {ex.Message}" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                message = ex.Message,
                error = "Unexpected Error",
                stackTrace = ex.StackTrace
            });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Transaction>> GetTransaction(string id)
    {
        try
        {
            Transaction transaction = await client.Transactions.GetAsync(id);
            return Ok(transaction);
        }
        catch (TransactionApiError ex)
        {
            return StatusCode(500, new
            {
                code = ex.Code,
                type = ex.Type,
                detail = ex.Detail,
                error = "Transaction API Error",
                documentationUrl = ex.DocumentationUrl,
                fieldErrors = ex.FieldErrors?.Select(fe => new
                {
                    code = fe.Code,
                    field = fe.Field,
                    message = fe.Message
                })
            });
        }
        catch (ApiError ex)
        {
            return StatusCode(500, new
            {
                error = "API Error",
                code = ex.Code,
                type = ex.Type,
                detail = ex.Detail,
                documentationUrl = ex.DocumentationUrl
            });
        }
        catch (MalformedResponse ex)
        {
            return StatusCode(500, new
            {
                message = ex.Message,
                error = "Malformed Response Error",
                innerException = ex.InnerException?.Message
            });
        }
        catch (SdkException ex)
        {
            return StatusCode(500, new { error = $"SDK Error: {ex.Message}" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                message = ex.Message,
                error = "Unexpected Error",
                stackTrace = ex.StackTrace
            });
        }
    }
}