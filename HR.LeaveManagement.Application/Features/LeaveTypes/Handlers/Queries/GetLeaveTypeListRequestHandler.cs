using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveTypes;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using HR.LeaveManagement.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Queries;
public class GetLeaveTypeListRequestHandler(
    ILeaveTypeRepository _leaveTypeRepository,
    IMapper _mapper)
    : IRequestHandler<GetLeaveTypeListRequest, List<LeaveTypeDto>>
{
    public async Task<List<LeaveTypeDto>> Handle(
        GetLeaveTypeListRequest request,
        CancellationToken cancellationToken)
    {
        var leaveTypes = await _leaveTypeRepository.GetAll();

        return _mapper.Map<List<LeaveTypeDto>>(leaveTypes);
    }
}

