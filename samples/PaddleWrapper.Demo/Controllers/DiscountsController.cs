using Microsoft.AspNetCore.Mvc;
using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Exceptions.ApiErrors;
using PaddleWrapper.Exceptions.SdkExceptions;
using PaddleWrapper.Resources.Discounts.Operations;
using PaddleWrapper.Resources.Shared.Operations.List;

namespace PaddleWrapper.Demo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DiscountsController(Client client) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<DiscountCollection>> GetDiscounts([FromQuery] int? page, [FromQuery] int? perPage)
    {
        try
        {
            Pager pager = new(
                after: null,
                orderBy: OrderBy.IdAscending(),
                perPage: perPage ?? 10
            );

            ListDiscounts listOperation = new(pager: pager);
            DiscountCollection discounts = await client.Discounts.ListAsync(listOperation);
            return Ok(discounts);
        }
        catch (DiscountApiError ex)
        {
            return StatusCode(500, new
            {
                code = ex.Code,
                type = ex.Type,
                detail = ex.Detail,
                error = "Discount API Error",
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
    public async Task<ActionResult<Discount>> GetDiscount(string id)
    {
        try
        {
            Discount discount = await client.Discounts.GetAsync(id);
            return Ok(discount);
        }
        catch (DiscountApiError ex)
        {
            return StatusCode(500, new
            {
                code = ex.Code,
                type = ex.Type,
                detail = ex.Detail,
                error = "Discount API Error",
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

    [HttpPost]
    public async Task<ActionResult<Discount>> CreateDiscount([FromBody] CreateDiscount createOperation)
    {
        try
        {
            Discount discount = await client.Discounts.CreateAsync(createOperation);
            return CreatedAtAction(nameof(GetDiscount), new { id = discount.Id }, discount);
        }
        catch (DiscountApiError ex)
        {
            return StatusCode(500, new
            {
                code = ex.Code,
                type = ex.Type,
                detail = ex.Detail,
                error = "Discount API Error",
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

    [HttpPatch("{id}")]
    public async Task<ActionResult<Discount>> UpdateDiscount(string id, [FromBody] UpdateDiscount updateOperation)
    {
        try
        {
            Discount discount = await client.Discounts.UpdateAsync(id, updateOperation);
            return Ok(discount);
        }
        catch (DiscountApiError ex)
        {
            return StatusCode(500, new
            {
                code = ex.Code,
                type = ex.Type,
                detail = ex.Detail,
                error = "Discount API Error",
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