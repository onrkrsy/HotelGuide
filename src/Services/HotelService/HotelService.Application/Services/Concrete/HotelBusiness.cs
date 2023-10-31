using AutoMapper;
using HotelService.Application.Models;
using HotelService.Application.Services.Abstract;
using HotelService.Domain.Entities;
using HotelService.Infrastructure.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using ServiceCore.Models.Abstract;
using ServiceCore.Models.Concrete;
using ServiceCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Application.Services.Concrete
{
    public class HotelBusiness : IHotelsBusiness
    {
        IHotelRepository _repository;
        private readonly IMapper _mapper;
        public HotelBusiness(IHotelRepository repository, IMapper mapper) 
        {
            _mapper = mapper;
            _repository = repository;
        } 
        public  async Task<Hotel> Add(CreateHotelDto model)
        {
            var hotel = new Hotel() { AuthorizedFirstName=model.AuthorizedFirstName, AuthorizedLastName=model.AuthorizedLastName, HotelName=model.Name, Location=model.Location };
            hotel.Id = Guid.NewGuid();
            return await _repository.Create(hotel);
        }
        public  async Task<Hotel> Update(UpdateHotelDto model)
        {
            var hotel = new Hotel() { AuthorizedFirstName = model.AuthorizedFirstName, AuthorizedLastName = model.AuthorizedLastName, HotelName = model.Name, Location = model.Location };

            return await _repository.Update(hotel);
        } 
        public async Task<List<Hotel>> GetAll()
        {
            var result = await _repository.GetAll();
            return result;
        }
        public async Task<Hotel> Get(Guid id)
        {
            return await _repository.Get(id);
        }

        public async Task Delete(Guid id)
        {
           await _repository.Delete(id);
        }

        public Task<List<StatisticsHotelDto>> GetReportDatasByLocation(string location)
        {
            var query = _repository.GetQuery()
                .Where(hotel => hotel.Location == location)
                .GroupBy(hotel => hotel.Location)
                .Select(group => new StatisticsHotelDto
                {
                    Location = group.Key,
                    HotelCount = group.Count(),
                    ConnectionCount = group.Sum(hotel => hotel.ContactInfos.Count)
                }); 
             return query.ToListAsync(); 
        }
     
    }
}
