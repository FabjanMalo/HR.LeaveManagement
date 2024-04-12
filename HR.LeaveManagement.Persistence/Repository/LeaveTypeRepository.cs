using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.Repository;
public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
{
    private readonly DataBaseContext _dbcontext;
    public LeaveTypeRepository(DataBaseContext dbcontext) : base(dbcontext)
    {
        _dbcontext = dbcontext;
    }
}
