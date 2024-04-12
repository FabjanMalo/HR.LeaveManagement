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
internal class GetLeaveAllocationListRequestHandler(
    ILeaveAllocationRepository _leaveAllocationRepository,
    IMapper _mapper)
    : IRequestHandler<GetLeaveAllocationListRequest, List<LeaveAllocationDto>>
{
    public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationListRequest request, CancellationToken cancellationToken)
    {
        var leaveAllocation = await _leaveAllocationRepository.GetLeaveAllocationListWithDetail();

        return _mapper.Map<List<LeaveAllocationDto>>(leaveAllocation);
    }
}
