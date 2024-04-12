using AutoMapper;
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
public class GetLeaveRequestListRequestHandler(
    ILeaveRequestRepository _leaveRequestRepository,
    IMapper _mapper)
    : IRequestHandler<GetLeaveRequestListRequest, List<LeaveRequestListDto>>
{
    public async Task<List<LeaveRequestListDto>> Handle(GetLeaveRequestListRequest request, CancellationToken cancellationToken)
    {
        var leaveRequests = await _leaveRequestRepository.GetLeaveRequestListWithDetail();

        return _mapper.Map<List<LeaveRequestListDto>>(leaveRequests);
    }
}
