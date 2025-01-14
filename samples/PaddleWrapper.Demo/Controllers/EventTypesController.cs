using Microsoft.AspNetCore.Mvc;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Exceptions.ApiErrors;
using PaddleWrapper.Exceptions.SdkExceptions;

namespace PaddleWrapper.Demo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventTypesController(Client client) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<EventTypeCollection>> GetEventTypes()
        {
            try
            {
                EventTypeCollection eventTypes = await client.EventTypes.ListAsync();
                return Ok(eventTypes);
            }
            catch (EventTypeApiError ex)
            {
                return StatusCode(500, new
                {
                    code = ex.Code,
                    type = ex.Type,
                    detail = ex.Detail,
                    error = "Event Type API Error",
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