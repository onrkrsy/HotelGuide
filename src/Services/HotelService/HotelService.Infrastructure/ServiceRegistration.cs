﻿using HotelService.Infrastructure.Context;
using HotelService.Infrastructure.Repositories.Abstract;
using HotelService.Infrastructure.Repositories.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Infrastructure
{
    public  static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection, IConfiguration configuration = null)
        {
            serviceCollection.AddDbContext<HotelGuideDbContext>(options =>
            {
                options.UseNpgsql(configuration?.GetConnectionString("PgSQL"));
                options.EnableSensitiveDataLogging();
            });
            serviceCollection.AddScoped<IHotelRepository, HotelRepository>();
            serviceCollection.AddScoped<IContactInfoRepository, ContactInfoRepository>();
        }
    }
}
