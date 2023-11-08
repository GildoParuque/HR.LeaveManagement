using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using HR.LeaveManagement.Application.Models;
using HR.LeaveManagement.Application.Contracts.Infrastructure;
using HR.LeaveManagement.Infrastructure.Mail;

namespace HR.LeaveManagement.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection ConfigureInfrastureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();

            return services;
        }
    }
}
