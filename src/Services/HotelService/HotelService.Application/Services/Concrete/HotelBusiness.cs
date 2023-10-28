using HotelService.Application.Services.Abstract;
using HotelService.Domain.Entities;
using HotelService.Infrastructure.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Application.Services.Concrete
{
    public class HotelBusiness : GenericBusiness<Hotel>, IHotelsBusiness
    {
        public HotelBusiness(IHotelRepository repository) : base(repository)
        {

        }
    }
}
