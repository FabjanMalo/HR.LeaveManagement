using FluentValidation;
using HR.LeaveManagement.Application.Persistence.Contracts;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators;
public class CreateLeaveAllocationDtoValidator : AbstractValidator<CreateLeaveAllocationDto>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    public CreateLeaveAllocationDtoValidator(ILeaveAllocationRepository leaveAllocationRepository)
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

    }
}
