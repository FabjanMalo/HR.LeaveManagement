using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveType.Validators;
using HR.LeaveManagement.Application.DTOs.LeaveTypes;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Queries;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands;
public class CreateLeaveTypeCommandHandler(
    ILeaveTypeRepository _leaveTypeRepository,
    IMapper _mapper)
    : IRequestHandler<CreateLeaveTypeCommand, BaseCommandResponse>
{
    public async Task<BaseCommandResponse> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();

        var validator = new CreateLeaveTypeDtoValidator();

        var validationResult = await validator.ValidateAsync(request.LeaveTypeDto);

        if (!validationResult.IsValid)
        {
            response.Success = false;
            response.Message = "Creation Failed";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
        }
        else
        {

            var leaveType = _mapper.Map<LeaveType>(request.LeaveTypeDto);

            leaveType = await _leaveTypeRepository.Add(leaveType);

            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = leaveType.Id;
        }

        return response;
    }
}
