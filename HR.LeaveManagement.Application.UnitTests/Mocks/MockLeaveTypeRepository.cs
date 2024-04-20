using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.UnitTests.Mocks;
public class MockLeaveTypeRepository
{
    public static Mock<ILeaveTypeRepository> GetLeaveTypeRepository()
    {
        var leaveTypes = new List<LeaveType>
        {
            new LeaveType
            {
               Id = 1,
               DeafultDays=10,
               Name= "Test Sick"
            },

            new LeaveType
            {
               Id = 2,
               DeafultDays=15,
               Name= "Test Vacation"
            }
        };

        var mockRepo = new Mock<ILeaveTypeRepository>();

        mockRepo.Setup(r => r.GetAll()).ReturnsAsync(leaveTypes);

        mockRepo.Setup(r => r.Add(It.IsAny<LeaveType>())).ReturnsAsync((LeaveType leaveType) =>
        {
            leaveTypes.Add(leaveType);
            return leaveType;
        });

        return mockRepo;
    }

}
