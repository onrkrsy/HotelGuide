using HotelService.Domain.Entities;
using ServiceCore.Models.Concrete;
using ServiceCore.Repositories;
namespace HotelService.Infrastructure.Repositories.Abstract
{
    public interface IHotelRepository : IGenericRepository<Hotel>
    {
        Task<List<StatisticsHotelDto>> GetReportDatasByLocation(string location);
    }
}
