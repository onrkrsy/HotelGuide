
using ReportService.Infrastructure.Context;
using ReportService.Infrastructure.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using ReportService.Domain.Enitites;
using ServiceCore.Repositories;

namespace ReportService.Infrastructure.Repositories.Concrete
{
    public class ReportRepository : GenericRepository<Report>, IReportRepository
    {
        private HotelGuideReportsDbContext context;
        public ReportRepository(HotelGuideReportsDbContext context) : base(context)
        {
            this.context = context;
        }  
    }
}
