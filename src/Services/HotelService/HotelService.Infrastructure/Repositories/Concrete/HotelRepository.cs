using HotelService.Infrastructure.Context;
using HotelService.Domain.Entities;
using HotelService.Infrastructure.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using ServiceCore.Repositories;
using MassTransit;
using ServiceCore.Models.Abstract;
using ServiceCore.Models.Concrete;

namespace HotelService.Infrastructure.Repositories.Concrete
{
    public class HotelRepository : GenericRepository<Hotel>, IHotelRepository
    {
        private HotelGuideDbContext _context; 
        public HotelRepository(HotelGuideDbContext context) : base(context)
        {
            this._context = context;
        }
        public virtual async Task<List<StatisticsHotelDto>> GetReportDatasByLocation(string location)
        {
            return   _context.Hotels
                 .Where(hotel => hotel.Location == location) // Filtreleme
                .GroupBy(hotel => hotel.Location)
                .Select(group => new StatisticsHotelDto
                {
                    Location = group.Key,
                    HotelCount = group.Count(),
                    ConnectionCount = group.Sum(hotel => hotel.ContactInfos.Count)
                })
                .ToList(); 
        }


    }
}
