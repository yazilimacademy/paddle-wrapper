using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Exceptions.ApiErrors;
using PaddleWrapper.Exceptions.SdkExceptions;
using PaddleWrapper.Resources.Businesses.Operations;
using PaddleWrapper.Resources.Shared.Operations.List;

namespace PaddleWrapper.Demo.Controllers
{
    [ApiController]
    [Route("api/customers/{customerId}/[controller]")]
    public class BusinessesController(Client client) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<BusinessCollection>> GetBusinesses(string customerId, [FromQuery] int? page, [FromQuery] int? perPage)
        {
            try
            {
                Pager pager = new(
                    after: null,
                    orderBy: OrderBy.IdAscending(),
                    perPage: perPage ?? 10
                );

                ListBusinesses listOperation = new(pager: pager);
                BusinessCollection businesses = await client.Businesses.ListAsync(customerId, listOperation);
                return Ok(businesses);
            }
            catch (BusinessApiError ex)
            {
                return StatusCode(500, new
                {
                    code = ex.Code,
                    type = ex.Type,
                    detail = ex.Detail,
                    error = "Business API Error",
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
                Console.WriteLine(JsonConvert.SerializeObject(ex, Formatting.Indented));
                return StatusCode(500, new
                {
                    message = ex.Message,
                    error = "Malformed Response Error",
                    innerException = ex.InnerException?.Message
                });
            }
            catch (SdkException ex)
            {
                Console.WriteLine(JsonConvert.SerializeObject(ex, Formatting.Indented));
                return StatusCode(500, new { error = $"SDK Error: {ex.Message}" });
            }
            catch (Exception ex)
            {
                Console.WriteLine(JsonConvert.SerializeObject(ex, Formatting.Indented));
                return StatusCode(500, new
                {
                    message = ex.Message,
                    error = "Unexpected Error",
                    stackTrace = ex.StackTrace
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Business>> GetBusiness(string customerId, string id)
        {
            try
            {
                Business business = await client.Businesses.GetAsync(customerId, id);
                return Ok(business);
            }
            catch (BusinessApiError ex)
            {
                return StatusCode(500, new
                {
                    code = ex.Code,
                    type = ex.Type,
                    detail = ex.Detail,
                    error = "Business API Error",
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
        public async Task<ActionResult<Business>> CreateBusiness(string customerId, [FromBody] CreateBusiness createOperation)
        {
            try
            {
                Business business = await client.Businesses.CreateAsync(customerId, createOperation);
                return CreatedAtAction(nameof(GetBusiness), new { customerId, id = business.Id }, business);
            }
            catch (BusinessApiError ex)
            {
                return StatusCode(500, new
                {
                    code = ex.Code,
                    type = ex.Type,
                    detail = ex.Detail,
                    error = "Business API Error",
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
        public async Task<ActionResult<Business>> UpdateBusiness(string customerId, string id, [FromBody] UpdateBusiness updateOperation)
        {
            try
            {
                Business business = await client.Businesses.UpdateAsync(customerId, id, updateOperation);
                return Ok(business);
            }
            catch (BusinessApiError ex)
            {
                return StatusCode(500, new
                {
                    code = ex.Code,
                    type = ex.Type,
                    detail = ex.Detail,
                    error = "Business API Error",
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
        public async Task<ActionResult<Business>> ArchiveBusiness(string customerId, string id)
        {
            try
            {
                Business business = await client.Businesses.ArchiveAsync(customerId, id);
                return Ok(business);
            }
            catch (BusinessApiError ex)
            {
                return StatusCode(500, new
                {
                    code = ex.Code,
                    type = ex.Type,
                    detail = ex.Detail,
                    error = "Business API Error",
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