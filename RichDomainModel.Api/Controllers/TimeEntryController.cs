using MediatR;
using Microsoft.AspNetCore.Mvc;
using RichDomainModel.Application.TimeEntry.Commands.CreateTimeEntry;
using RichDomainModel.Application.TimeEntry.Queries.GetTimeEntryById;

namespace RichDomainModel.Api.Controllers;

/// <summary>
/// Time entry API
/// </summary>
[Route("api/time-entries")]
public class TimeEntryController(ISender mediatr) : ControllerBase
{
    /// <summary>
    /// Get time entry by id
    /// </summary>
    /// <param name="id">Time entry id</param>
    /// <returns>Time entry or not found</returns>
    [HttpGet("{id:guid}", Name = "GetTimeEntryById")]
    [ProducesResponseType(typeof(GetTimeEntryByIdResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetTimeEntryByIdResponse>> Get([FromRoute] Guid id)
    {
        var response = await mediatr.Send(new GetTimeEntryByIdRequest { Id = id });
        return Ok(response);
    }
    
    /// <summary>
    /// Create time entry
    /// </summary>
    /// <param name="request">Create time entry request</param>
    /// <returns>Created time entry</returns>
    [HttpPost(Name = "CreateTimeEntry")]
    [ProducesResponseType(typeof(CreateTimeEntryResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status422UnprocessableEntity)]
    // TODO: I dont think [FromBody] is necessary
    public async Task<CreatedAtActionResult> Create([FromBody] CreateTimeEntryRequest request)
    {
        var response = await mediatr.Send(request);
        return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
    }
}