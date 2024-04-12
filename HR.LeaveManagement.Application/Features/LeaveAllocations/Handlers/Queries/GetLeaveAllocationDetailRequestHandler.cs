using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Queries;
using HR.LeaveManagement.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Handlers.Queries;
public class GetLeaveAllocationDetailRequestHandler(
    ILeaveAllocationRepository _leaveAllocation,
    IMapper _mapper)
    : IRequestHandler<GetLeaveAllocationDetailRequest, LeaveAllocationDto>
{
    public async Task<LeaveAllocationDto> Handle(GetLeaveAllocationDetailRequest request, CancellationToken cancellationToken)
    {
        var leaveAllocation = await _leaveAllocation.GetLeaveAllocationWithDetail(request.Id);

        return _mapper.Map<LeaveAllocationDto>(leaveAllocation);
    }
}
