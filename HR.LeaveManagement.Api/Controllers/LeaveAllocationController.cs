using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.LeaveManagement.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LeaveAllocationController(IMediator _mediator) : ControllerBase
{
    // GET: api/<LeaveAllocationController>
    [HttpGet] 
    public async Task<ActionResult<List<LeaveAllocationDto>>> Get()
    {
        var query = new GetLeaveAllocationListRequest();

        var allocationType = await _mediator.Send(query);

        return Ok(allocationType);

    }

    // GET api/<LeaveAllocationController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<LeaveAllocationDto>> Get(int id)
    {
        var query = new GetLeaveAllocationDetailRequest { Id = id };

        var allocationType = await _mediator.Send(query);

        return Ok(allocationType);
    }

    // POST api/<LeaveAllocationController>
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreateLeaveAllocationDto createLeaveAllocation)
    {
        var command = new CreateLeaveAllocationCommand { LeaveAllocationDto = createLeaveAllocation };

        var result = await _mediator.Send(command);

        return Ok(result);
    }

    // PUT api/<LeaveAllocationController>/5
    [HttpPut]
    public async Task<ActionResult> Put([FromBody] UpdateLeaveAllocationDto updateLeaveAllocation)
    {
        var command = new UpdateLeaveAllocationCommand { LeaveAllocationDto = updateLeaveAllocation };

        await _mediator.Send(command);

        return NoContent();
    }

    // DELETE api/<LeaveAllocationController>/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteLeaveAllocationCommand { Id = id };

        await _mediator.Send(command);

        return NoContent();
    }
}
