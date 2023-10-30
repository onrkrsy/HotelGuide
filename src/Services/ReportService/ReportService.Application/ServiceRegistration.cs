using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReportService.Application;
using ReportService.Infrastructure.Context;
using ReportService.Infrastructure.Repositories.Abstract;
using ReportService.Infrastructure.Repositories.Concrete;
using ServiceCore.Extensions;

namespace ReportService.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection serviceCollection, IConfiguration configuration = null)
        {
            
        }

    }
}
