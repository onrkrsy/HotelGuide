using HotelService.Domain.Entities;
using HotelService.Infrastructure.Context;
using HotelService.Infrastructure.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace HotelService.Infrastructure.Repositories.Concrete
{
    public class ContactInfoRepository : GenericRepository<ContactInfo>, IContactInfoRepository
    {
        private HotelGuideDbContext context;
        public ContactInfoRepository(HotelGuideDbContext context) : base(context)
        {
            this.context = context;
        }  
    }
}
