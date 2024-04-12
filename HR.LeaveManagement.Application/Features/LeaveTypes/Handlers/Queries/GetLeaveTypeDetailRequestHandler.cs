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
public class GetLeaveTypeDetailRequestHandler(
    ILeaveTypeRepository _leaveTypeRepository,
    IMapper _mapper) : IRequestHandler<GetLeaveTypeDetailRequest, LeaveTypeDto>
{
    public async Task<LeaveTypeDto> Handle(GetLeaveTypeDetailRequest request, CancellationToken cancellationToken)
    {
        var leaveType = await _leaveTypeRepository.Get(request.Id);

        return _mapper.Map<LeaveTypeDto>(leaveType);
    }
}
