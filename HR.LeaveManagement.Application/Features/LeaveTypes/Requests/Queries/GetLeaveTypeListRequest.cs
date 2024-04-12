﻿using HR.LeaveManagement.Application.DTOs.LeaveTypes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
public class GetLeaveTypeListRequest : IRequest<List<LeaveTypeDto>>
{
}
