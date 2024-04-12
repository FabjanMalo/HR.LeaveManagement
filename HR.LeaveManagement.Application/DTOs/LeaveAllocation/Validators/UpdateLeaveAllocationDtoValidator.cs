using FluentValidation;
using HR.LeaveManagement.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators;
public class UpdateLeaveAllocationDtoValidator : AbstractValidator<UpdateLeaveAllocationDto>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;

    public UpdateLeaveAllocationDtoValidator(ILeaveAllocationRepository leaveAllocationRepository)
    {
        _leaveAllocationRepository = leaveAllocationRepository;

        RuleFor(p => p.NumberOfDays)
         .GreaterThan(0);

        RuleFor(p => p.Period)
            .GreaterThanOrEqualTo(DateTime.Now.Year);

        RuleFor(p => p.LeaveTypeId)
           .GreaterThan(0)
        .MustAsync(async (id, token) =>
        {
            var leaveRequestExist = await _leaveAllocationRepository.Exists(id);

            return !leaveRequestExist;
        }).WithMessage("{PropertyName} does not exist");


        RuleFor(p => p.Id)
            .NotNull().WithMessage("{PropertyName} must be present");


    }
}
