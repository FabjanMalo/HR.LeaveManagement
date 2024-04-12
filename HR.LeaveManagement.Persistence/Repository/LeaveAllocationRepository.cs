using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.Repository;
public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
{
    private readonly DataBaseContext _dbcontext;
    public LeaveAllocationRepository(DataBaseContext dbcontext) : base(dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public async Task<List<LeaveAllocation>> GetLeaveAllocationListWithDetail()
    {
        var leaveAllocation = await _dbcontext.LeaveAllocations
           .Include(q => q.LeaveType)
           .ToListAsync();

        return leaveAllocation;
    }

    public async Task<LeaveAllocation> GetLeaveAllocationWithDetail(int id)
    {
        var leaveAllocation = await _dbcontext.LeaveAllocations
             .Include(q => q.LeaveType)
             .FirstOrDefaultAsync(q => q.Id == id);

        return leaveAllocation;
    }
}
