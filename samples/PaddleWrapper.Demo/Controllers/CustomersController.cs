using Microsoft.AspNetCore.Mvc;
using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Exceptions.ApiErrors;
using PaddleWrapper.Exceptions.SdkExceptions;
using PaddleWrapper.Resources.Customers.Operations;
using PaddleWrapper.Resources.Shared.Operations.List;

namespace PaddleWrapper.Demo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController(Client client) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<CustomerCollection>> GetCustomers([FromQuery] int? page, [FromQuery] int? perPage)
    {
        try
        {
            Pager pager = new(
                after: null,
                orderBy: OrderBy.IdAscending(),
                perPage: perPage ?? 10
            );

            ListCustomers listOperation = new(pager: pager);
            CustomerCollection customers = await client.Customers.ListAsync(listOperation);
            return Ok(customers);
        }
        catch (CustomerApiError ex)
        {
            return StatusCode(500, new
            {
                code = ex.Code,
                type = ex.Type,
                detail = ex.Detail,
                error = "Customer API Error",
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
    public async Task<ActionResult<Customer>> GetCustomer(string id)
    {
        try
        {
            Customer customer = await client.Customers.GetAsync(id);
            return Ok(customer);
        }
        catch (CustomerApiError ex)
        {
            return StatusCode(500, new
            {
                code = ex.Code,
                type = ex.Type,
                detail = ex.Detail,
                error = "Customer API Error",
                documentationUrl = ex.DocumentationUrl,
                fieldErrors = ex.FieldErrors?.Select(fe => new
                {
                    field = fe.Field,
                    code = fe.Code,
                    message = fe.Message
                })
            });
        }
        catch (ApiError ex)
        {
            return StatusCode(500, new
            {
                code = ex.Code,
                type = ex.Type,
                detail = ex.Detail,
                error = "API Error",
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

    [HttpPost]
    public async Task<ActionResult<Customer>> CreateCustomer([FromBody] CreateCustomer createOperation)
    {
        try
        {
            Customer customer = await client.Customers.CreateAsync(createOperation);
            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
        }
        catch (CustomerApiError ex)
        {
            return StatusCode(500, new
            {
                code = ex.Code,
                type = ex.Type,
                detail = ex.Detail,
                error = "Customer API Error",
                documentationUrl = ex.DocumentationUrl,
                fieldErrors = ex.FieldErrors?.Select(fe => new
                {
                    field = fe.Field,
                    code = fe.Code,
                    message = fe.Message
                })
            });
        }
        catch (ApiError ex)
        {
            return StatusCode(500, new
            {
                code = ex.Code,
                type = ex.Type,
                detail = ex.Detail,
                error = "API Error",
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

    [HttpPatch("{id}")]
    public async Task<ActionResult<Customer>> UpdateCustomer(string id, [FromBody] UpdateCustomer updateOperation)
    {
        try
        {
            Customer customer = await client.Customers.UpdateAsync(id, updateOperation);
            return Ok(customer);
        }
        catch (CustomerApiError ex)
        {
            return StatusCode(500, new
            {
                code = ex.Code,
                type = ex.Type,
                detail = ex.Detail,
                error = "Customer API Error",
                documentationUrl = ex.DocumentationUrl,
                fieldErrors = ex.FieldErrors?.Select(fe => new
                {
                    field = fe.Field,
                    code = fe.Code,
                    message = fe.Message
                })
            });
        }
        catch (ApiError ex)
        {
            return StatusCode(500, new
            {
                code = ex.Code,
                type = ex.Type,
                detail = ex.Detail,
                error = "API Error",
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