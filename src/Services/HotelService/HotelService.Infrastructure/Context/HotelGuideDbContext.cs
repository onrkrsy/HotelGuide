using HotelService.Domain.Entities;
using HotelService.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Infrastructure.Context
{
    public class HotelGuideDbContext : DbContext
    {
     
        public HotelGuideDbContext(DbContextOptions<HotelGuideDbContext> options) : base(options)
        {

        }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<Hotel> Hotels { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
             
        }
    }
}
