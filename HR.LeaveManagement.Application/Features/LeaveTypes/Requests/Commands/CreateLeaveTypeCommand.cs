﻿using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Application.DTOs.LeaveTypes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
public class CreateLeaveTypeCommand : IRequest<int>
{
    public CreateLeaveTypeDto LeaveTypeDto { get; set; }
}
