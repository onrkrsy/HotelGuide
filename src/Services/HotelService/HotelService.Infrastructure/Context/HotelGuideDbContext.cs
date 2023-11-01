using HotelService.Domain.Entities;
using HotelService.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HotelService.Infrastructure.Context
{
    public class HotelGuideDbContext : DbContext
    {
     
        public HotelGuideDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<Hotel> Hotels { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            //options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
            base.OnModelCreating(modelBuilder); 
             
        }
        //For Auiditable Logs
        private void TrackChanges()
        { 
            
        }
    }
}
