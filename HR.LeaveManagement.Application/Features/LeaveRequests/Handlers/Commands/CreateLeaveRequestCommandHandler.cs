using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators;
using HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HR.LeaveManagement.Application.Models;
using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Application.Persistence.Infrastructure;
using HR.LeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands;
public class CreateLeaveRequestCommandHandler(
    ILeaveRequestRepository _leaveRequestRepository,
    IEmailSender _emailSender,
    IMapper _mapper)
    : IRequestHandler<CreateLeaveRequestCommand, int>
{
    public async Task<int> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateLeaveRequestDtoValidator(_leaveRequestRepository);

        var validationResult = await validator.ValidateAsync(request.LeaveRequestDto);

        if (!validationResult.IsValid)
        {
            throw new ValidationExceptions(validationResult);
        }

        var leaveRequest = _mapper.Map<LeaveRequest>(request.LeaveRequestDto);

        leaveRequest = await _leaveRequestRepository.Add(leaveRequest);

        var email = new Email
        {
            To = "employee@org.com",
            Body = $"Your leave request for {request.LeaveRequestDto.StartDate:D} to {request.LeaveRequestDto.EndDate:D}" +
            $"has been submitted successfully.",
            Subject = " Leave Request Submitted"

        };

        try
        {
            await _emailSender.SendEmail(email);
        }
        catch (Exception ex)
        {

            throw;
        }
        return leaveRequest.Id;

    }
}
