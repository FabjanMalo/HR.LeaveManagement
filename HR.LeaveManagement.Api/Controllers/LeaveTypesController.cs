﻿using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Application.DTOs.LeaveTypes;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagement.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.LeaveManagement.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class LeaveTypesController(IMediator _mediator) : ControllerBase
{
    // GET: api/<LeaveTypesController>
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<List<LeaveTypeDto>>> Get()
    {
        var leaveType = await _mediator.Send(new GetLeaveTypeListRequest());

        return Ok(leaveType);
    }
    // GET api/<LeaveTypesController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<LeaveTypeDto>> Get(int id)
    {
        var leaveType = await _mediator.Send(new GetLeaveTypeDetailRequest { Id = id });

        return Ok(leaveType);
    }

    // POST api/<LeaveTypesController>
    [HttpPost]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateLeaveTypeDto leaveTypeDto)
    {
        var command = new CreateLeaveTypeCommand { LeaveTypeDto = leaveTypeDto };

        var result = await _mediator.Send(command);

        return Ok(result);
    }

    // PUT api/<LeaveTypesController>
    [HttpPut]
    public async Task<ActionResult> Put([FromBody] LeaveTypeDto leaveType)
    {
        var command = new UpdateLeaveTypeCommand { LeaveTypeDto = leaveType };

        await _mediator.Send(command);

        return NoContent();
    }

    // DELETE api/<LeaveTypesController>/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteLeaveTypeCommand { Id = id };

        await _mediator.Send(command);

        return NoContent();
    }
}
