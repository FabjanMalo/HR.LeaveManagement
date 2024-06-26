﻿using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Queries;
using HR.LeaveManagement.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Queries;
public class GetLeaveRequestDetailRequestHandler(
    ILeaveRequestRepository _leaveRequestRepository,
    IMapper _mapper)
    : IRequestHandler<GetLeaveRequestDetailRequest, LeaveRequestDto>
{
    public async Task<LeaveRequestDto> Handle(GetLeaveRequestDetailRequest request, CancellationToken cancellationToken)
    {
        var leaveRequest = await _leaveRequestRepository.GetLeaveRequestWithDetail(request.Id);

        return _mapper.Map<LeaveRequestDto>(leaveRequest);
    }
}
