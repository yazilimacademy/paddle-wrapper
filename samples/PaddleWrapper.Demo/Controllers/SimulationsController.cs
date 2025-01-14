using Microsoft.AspNetCore.Mvc;
using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Exceptions.ApiErrors;
using PaddleWrapper.Exceptions.SdkExceptions;
using PaddleWrapper.Resources.Shared.Operations.List;
using PaddleWrapper.Resources.Simulations.Operations;

namespace PaddleWrapper.Demo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SimulationsController(Client client) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<SimulationCollection>> GetSimulations([FromQuery] int? page, [FromQuery] int? perPage)
    {
        try
        {
            Pager pager = new(
                after: null,
                orderBy: OrderBy.IdAscending(),
                perPage: perPage ?? 10
            );

            ListSimulations listOperation = new(pager: pager);
            SimulationCollection simulations = await client.Simulations.ListAsync(listOperation);
            return Ok(simulations);
        }
        catch (SimulationApiError ex)
        {
            return StatusCode(500, new
            {
                code = ex.Code,
                type = ex.Type,
                detail = ex.Detail,
                error = "Simulation API Error",
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
    public async Task<ActionResult<Simulation>> GetSimulation(string id)
    {
        try
        {
            Simulation simulation = await client.Simulations.GetAsync(id);
            return Ok(simulation);
        }
        catch (SimulationApiError ex)
        {
            return StatusCode(500, new
            {
                code = ex.Code,
                type = ex.Type,
                detail = ex.Detail,
                error = "Simulation API Error",
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
    public async Task<ActionResult<Simulation>> CreateSimulation([FromBody] CreateSimulation createOperation)
    {
        try
        {
            Simulation simulation = await client.Simulations.CreateAsync(createOperation);
            return CreatedAtAction(nameof(GetSimulation), new { id = simulation.Id }, simulation);
        }
        catch (SimulationApiError ex)
        {
            return StatusCode(500, new
            {
                code = ex.Code,
                type = ex.Type,
                detail = ex.Detail,
                error = "Simulation API Error",
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
    public async Task<ActionResult<Simulation>> UpdateSimulation(string id, [FromBody] UpdateSimulation updateOperation)
    {
        try
        {
            Simulation simulation = await client.Simulations.UpdateAsync(id, updateOperation);
            return Ok(simulation);
        }
        catch (SimulationApiError ex)
        {
            return StatusCode(500, new
            {
                code = ex.Code,
                type = ex.Type,
                detail = ex.Detail,
                error = "Simulation API Error",
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