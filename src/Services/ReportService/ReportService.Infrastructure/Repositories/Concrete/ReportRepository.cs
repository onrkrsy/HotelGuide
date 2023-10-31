
using ReportService.Infrastructure.Context;
using ReportService.Infrastructure.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using ReportService.Domain.Enitites;
using ServiceCore.Repositories;

namespace ReportService.Infrastructure.Repositories.Concrete
{
    public class ReportRepository : GenericRepository<Report>, IReportRepository
    {
        private HotelGuideReportsDbContext _context;
        public ReportRepository(HotelGuideReportsDbContext context) : base(context)
        {
            _context = context;
        }  
    }
}
