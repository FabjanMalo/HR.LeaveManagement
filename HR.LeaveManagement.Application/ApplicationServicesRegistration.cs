using HR.LeaveManagement.Application.DTOs.Common;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application;
public static class ApplicationServicesRegistration
{
    public static IServiceCollection ConfigureApplicationServices(
        this IServiceCollection service)
    {
        service.AddAutoMapper(Assembly.GetExecutingAssembly());

        service.AddMediatR(c =>
        {
            c.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        return service;
    }


}
