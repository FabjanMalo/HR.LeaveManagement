using AutoMapper;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands;
public class DeleteLeaveTypeCommandHandler(
    ILeaveTypeRepository _leaveTypeRepository,
    IMapper _mapper)
    : IRequestHandler<DeleteLeaveTypeCommand, Unit>
{
    public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var leaveType = await _leaveTypeRepository.Get(request.Id);

        if (leaveType == null)
        {
            throw new NotFoundException(nameof(LeaveType), request.Id);
        }

        await _leaveTypeRepository.Delete(leaveType);

        return Unit.Value;
    }
}
