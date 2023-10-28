using HotelService.Application.Services;
using HotelService.Application.Services.Abstract;
using HotelService.Application.Services.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelService.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection serviceCollection, IConfiguration configuration = null)
        {
           
            serviceCollection.AddScoped<IHotelsBusiness, HotelBusiness>();
            serviceCollection.AddScoped<IContactInfoBusiness, ContactInfoBusiness>();
        }
    }
}