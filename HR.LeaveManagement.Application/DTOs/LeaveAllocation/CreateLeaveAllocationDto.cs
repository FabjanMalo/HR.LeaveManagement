﻿using HR.LeaveManagement.Application.DTOs.Common;
using HR.LeaveManagement.Application.DTOs.LeaveTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation;
public class CreateLeaveAllocationDto
{
    public int NumberOfDays { get; set; }

    public int LeaveTypeId { get; set; }

    public int Period { get; set; }
}
