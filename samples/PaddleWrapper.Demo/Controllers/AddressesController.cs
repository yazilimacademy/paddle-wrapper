using Microsoft.AspNetCore.Mvc;
using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Exceptions.ApiErrors;
using PaddleWrapper.Exceptions.SdkExceptions;
using PaddleWrapper.Resources.Addresses.Operations;
using PaddleWrapper.Resources.Shared.Operations.List;

namespace PaddleWrapper.Demo.Controllers
{
    [ApiController]
    [Route("api/customers/{customerId}/[controller]")]
    public class AddressesController(Client client) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<AddressCollection>> GetAddresses(string customerId, [FromQuery] int? page, [FromQuery] int? perPage)
        {
            try
            {
                Pager pager = new(
                    after: null,
                    orderBy: OrderBy.IdAscending(),
                    perPage: perPage ?? 10
                );

                ListAddresses listOperation = new(pager: pager);
                AddressCollection addresses = await client.Addresses.ListAsync(customerId, listOperation);
                return Ok(addresses);
            }
            catch (AddressApiError ex)
            {
                return StatusCode(500, new
                {
                    code = ex.Code,
                    type = ex.Type,
                    detail = ex.Detail,
                    error = "Address API Error",
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
        public async Task<ActionResult<Address>> GetAddress(string customerId, string id)
        {
            try
            {
                Address address = await client.Addresses.GetAsync(customerId, id);
                return Ok(address);
            }
            catch (AddressApiError ex)
            {
                return StatusCode(500, new
                {
                    code = ex.Code,
                    type = ex.Type,
                    detail = ex.Detail,
                    error = "Address API Error",
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
        public async Task<ActionResult<Address>> CreateAddress(string customerId, [FromBody] CreateAddress createOperation)
        {
            try
            {
                Address address = await client.Addresses.CreateAsync(customerId, createOperation);
                return CreatedAtAction(nameof(GetAddress), new { customerId, id = address.Id }, address);
            }
            catch (AddressApiError ex)
            {
                return StatusCode(500, new
                {
                    code = ex.Code,
                    type = ex.Type,
                    detail = ex.Detail,
                    error = "Address API Error",
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
        public async Task<ActionResult<Address>> UpdateAddress(string customerId, string id, [FromBody] UpdateAddress updateOperation)
        {
            try
            {
                Address address = await client.Addresses.UpdateAsync(customerId, id, updateOperation);
                return Ok(address);
            }
            catch (AddressApiError ex)
            {
                return StatusCode(500, new
                {
                    code = ex.Code,
                    type = ex.Type,
                    detail = ex.Detail,
                    error = "Address API Error",
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

        [HttpPost("{id}/archive")]
        public async Task<ActionResult<Address>> ArchiveAddress(string customerId, string id)
        {
            try
            {
                Address address = await client.Addresses.ArchiveAsync(customerId, id);
                return Ok(address);
            }
            catch (AddressApiError ex)
            {
                return StatusCode(500, new
                {
                    code = ex.Code,
                    type = ex.Type,
                    detail = ex.Detail,
                    error = "Address API Error",
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
}