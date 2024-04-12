using HR.LeaveManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.DTOs.LeaveTypes;
public class LeaveTypeDto : BaseDto
{
    public string Name { get; set; }

    public int DeafultDays { get; set; }
}
