using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReportService.Application.Services.Abstract;
using ReportService.Application.Services.Concrete;

namespace ReportService.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection serviceCollection, IConfiguration configuration = null)
        { 
            serviceCollection.AddScoped<IReportBusiness, ReportBusiness>();  
        }

    }
}
