﻿using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.LeaveManagement.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LeaveRequestController(IMediator _mediator) : ControllerBase
{
    // GET: api/<LeaveRequestController>
    [HttpGet]
    public async Task<ActionResult<List<LeaveRequestListDto>>> Get()
    {
        var query = new GetLeaveRequestListRequest();

        var leaveRequest = await _mediator.Send(query);

        return Ok(leaveRequest);
    }

    // GET api/<LeaveRequestController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<LeaveRequestDto>> Get(int id)
    {
        var query = new GetLeaveRequestDetailRequest { Id = id };

        var leaveRequest = await _mediator.Send(query);

        return Ok(leaveRequest);
    }

    // POST api/<LeaveRequestController>
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreateLeaveRequestDto leaveRequestDto)
    {
        var command = new CreateLeaveRequestCommand { LeaveRequestDto = leaveRequestDto };

        var result = await _mediator.Send(command);

        return Ok(result);

    }

    // PUT api/<LeaveRequestController>/5
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] UpdateLeaveRequestDto leaveRequestDto)
    {
        var command = new UpdateLeaveRequestCommand { Id = id, LeaveRequestDto = leaveRequestDto };

        await _mediator.Send(command);

        return NoContent();

    }

    // PUT api/<LeaveRequestController>/changeapproval/5
    [HttpPut("changeapproval/{id}")]
    public async Task<ActionResult> ChangeApproval(int id, [FromBody] ChangeLeaveRequestApprovalDto changeLeaveRequest)
    {
        var command = new UpdateLeaveRequestCommand { Id = id, ChangeLeaveRequestApprovalDto = changeLeaveRequest };

        await _mediator.Send(command);

        return NoContent();

    }

    // DELETE api/<LeaveRequestController>/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteLeaveRequestCommand { Id = id };

        await _mediator.Send(command);

        return NoContent();

    }
}
