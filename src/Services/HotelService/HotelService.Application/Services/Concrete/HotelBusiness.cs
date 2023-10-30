using AutoMapper;
using HotelService.Application.Models;
using HotelService.Application.Services.Abstract;
using HotelService.Domain.Entities;
using HotelService.Infrastructure.Repositories.Abstract;
using ServiceCore.Models.Abstract;
using ServiceCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Application.Services.Concrete
{
    public class HotelBusiness :IHotelsBusiness
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
            var hotel = _mapper.Map<Hotel>(model);
            hotel.Id = new Guid();
            return await _repository.Create(hotel);
        }
        public  async Task<Hotel> Update(UpdateHotelDto model)
        {
            var hotel = _mapper.Map<Hotel>(model);
         
            return await _repository.Update(hotel);
        } 
        public async Task<List<Hotel>> GetAll()
        {
            var result = await _repository.GetAll();
            return _mapper.Map<List<Hotel>, List<Hotel>>(result);
        }
        public async Task<Hotel> Get(Guid id)
        {
            return await _repository.Get(id);
        }

        public async Task Delete(Guid id)
        {
           await _repository.Delete(id);
        }

      
    }
}
