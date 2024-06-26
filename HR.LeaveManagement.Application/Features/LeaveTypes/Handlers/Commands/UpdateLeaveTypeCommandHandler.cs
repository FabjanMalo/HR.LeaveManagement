﻿using AutoMapper;
using FluentValidation;
using HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators;
using HR.LeaveManagement.Application.DTOs.LeaveType.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands;
public class UpdateLeaveTypeCommandHandler(
    ILeaveTypeRepository _leaveTypeRepository,
    IMapper _mapper)
    : IRequestHandler<UpdateLeaveTypeCommand, Unit>
{
    public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateLeaveTypeDtoValidator();

        var validationResult = await validator.ValidateAsync(request.LeaveTypeDto);

        if (!validationResult.IsValid)
        {
            throw new ValidationExceptions(validationResult);
        }

        var leaveType = await _leaveTypeRepository.Get(request.LeaveTypeDto.Id);

        _mapper.Map(request.LeaveTypeDto, leaveType);

        await _leaveTypeRepository.Update(leaveType);

        return Unit.Value;
    }
}
