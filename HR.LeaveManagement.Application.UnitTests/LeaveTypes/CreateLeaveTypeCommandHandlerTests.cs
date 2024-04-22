using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Application.DTOs.LeaveTypes;
using HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands;
using HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Queries;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Application.Profiles;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.UnitTests.LeaveTypes;
public class CreateLeaveTypeCommandHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<ILeaveTypeRepository> _mockRepo;
    private readonly CreateLeaveTypeDto _leaveTypeDto;
    public CreateLeaveTypeCommandHandlerTests()
    {
        _mockRepo = MockLeaveTypeRepository.GetLeaveTypeRepository();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
        _leaveTypeDto = new CreateLeaveTypeDto
        {
            DeafultDays = 10,
            Name = "Test dto"
        };
    }

    [Fact]
    public async Task CreateLeaveTypeTest()
    {
        var handler = new CreateLeaveTypeCommandHandler(_mockRepo.Object, _mapper);

        var result = await handler.Handle(new CreateLeaveTypeCommand()
        { LeaveTypeDto = _leaveTypeDto }, CancellationToken.None);

        var leaveType = await _mockRepo.Object.GetAll();

        result.ShouldBeOfType<BaseCommandResponse>();
        
        leaveType.Count.ShouldBe(3);

        
    }
}
