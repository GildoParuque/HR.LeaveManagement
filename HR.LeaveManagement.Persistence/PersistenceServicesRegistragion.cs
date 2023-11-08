using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace HR.LeaveManagement.Persistence
{
    public static class  PersistenceServicesRegistragion
    {
      public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
      {
            services.AddDbContext<HrLeaveManagementDbContext>(options =>
              options.UseSqlServer(configuration.GetConnectionString("LeaveManagementConnectionString")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();

            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();

            services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();

            return services;
       }

    }
}
