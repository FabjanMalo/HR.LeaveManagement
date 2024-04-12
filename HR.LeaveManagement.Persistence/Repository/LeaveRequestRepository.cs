using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.Repository;
public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
{
    private readonly DataBaseContext _dbcontext;
    public LeaveRequestRepository(DataBaseContext dbcontext) : base(dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? ApprovalStatus)
    {
        leaveRequest.Approved = ApprovalStatus;
        _dbcontext.Entry(leaveRequest).State = EntityState.Modified;

        await _dbcontext.SaveChangesAsync();
    }


    public async Task<List<LeaveRequest>> GetLeaveRequestListWithDetail()
    {
        var leaveRequest = await _dbcontext.LeaveRequests
            .Include(q => q.LeaveType)
            .ToListAsync();

        return leaveRequest;
    }

    public async Task<LeaveRequest> GetLeaveRequestWithDetail(int id)
    {
        var leaveRequest = await _dbcontext.LeaveRequests
            .Include(q => q.LeaveType)
            .FirstOrDefaultAsync(q => q.Id == id);

        return leaveRequest;
    }
}
