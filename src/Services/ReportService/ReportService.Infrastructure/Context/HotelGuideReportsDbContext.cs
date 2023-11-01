using ReportService.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportService.Domain.Enitites;

namespace ReportService.Infrastructure.Context
{
    public class HotelGuideReportsDbContext : DbContext
    {
     
        public HotelGuideReportsDbContext(DbContextOptions<HotelGuideReportsDbContext> options) : base(options)
        {

        }
        public DbSet<Report> Reports { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
             
        }
    }
}
