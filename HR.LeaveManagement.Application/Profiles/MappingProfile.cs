﻿using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Application.DTOs.LeaveTypes;
using HR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Profiles;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();

        CreateMap<LeaveType, CreateLeaveTypeDto>().ReverseMap();


        CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();

        CreateMap<LeaveAllocation, CreateLeaveAllocationDto>().ReverseMap();

        CreateMap<LeaveAllocation, UpdateLeaveAllocationDto>().ReverseMap();



        CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();

        CreateMap<LeaveRequest, CreateLeaveRequestDto>().ReverseMap();

        CreateMap<LeaveRequest, UpdateLeaveRequestDto>().ReverseMap();

        CreateMap<LeaveRequest, LeaveRequestListDto>().ReverseMap();
    }
}
