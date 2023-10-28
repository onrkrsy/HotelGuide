using HotelService.Infrastructure.Context;
using HotelService.Domain.Entities;
using HotelService.Infrastructure.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace HotelService.Infrastructure.Repositories.Concrete
{
    public class HotelRepository : GenericRepository<Hotel>, IHotelRepository
    {
        private HotelGuideDbContext context; 
        public HotelRepository(HotelGuideDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
