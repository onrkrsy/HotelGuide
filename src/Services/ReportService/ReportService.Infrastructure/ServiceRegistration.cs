using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReportService.Infrastructure.Context;
using ReportService.Infrastructure.Repositories.Abstract;
using ReportService.Infrastructure.Repositories.Concrete;

namespace ReportService.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection, IConfiguration configuration = null)
        {
            serviceCollection.AddDbContext<HotelGuideReportsDbContext>(options =>
            {
                options.UseNpgsql(configuration?.GetConnectionString("PgSQL"));
                options.EnableSensitiveDataLogging();
            });
            serviceCollection.AddScoped<IReportRepository, ReportRepository>(); 
        }

    }
}
