using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence;
public static class PersistanceServicesRegistration
{
    public static IServiceCollection ConfigurePersistanceServices
        (this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataBaseContext>(option =>
        option.UseSqlServer(
            configuration.GetConnectionString("LeaveManagementConnectingString")));


        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();

        services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();

        services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();

        return services;
    }
}
