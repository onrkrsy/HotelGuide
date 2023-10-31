using HotelService.Application.Models;
using HotelService.Domain.Entities;
using ServiceCore.Models.Abstract;
using ServiceCore.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Application.Services.Abstract
{
    public interface IHotelsBusiness
    {
        Task<Hotel> Add(CreateHotelDto model);
        Task<Hotel> Update(UpdateHotelDto model);
        Task<List<Hotel>> GetAll();
        Task<Hotel>Get(Guid id);
        Task Delete(Guid id);
        Task<List<StatisticsHotelDto>> GetReportDatasByLocation(string location);


    }
}
