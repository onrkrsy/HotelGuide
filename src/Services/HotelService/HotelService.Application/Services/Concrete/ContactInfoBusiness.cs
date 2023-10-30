using AutoMapper;
using HotelService.Application.Models;
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
    public class ContactInfoBusiness : IContactInfoBusiness
    {
        IContactInfoRepository _repository;
        private readonly IMapper _mapper;
        public ContactInfoBusiness(IContactInfoRepository repository, IMapper mapper) 
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<ContactInfo> Add(CreateContactInfoDto model)
        {
            var contact = _mapper.Map<ContactInfo>(model);
            contact.Id = new Guid();
            return await _repository.Create(contact);
        }
        public async Task<ContactInfo> Update(UpdateContactInfoDto model)
        {
            var contact = _mapper.Map<ContactInfo>(model);     
            return await _repository.Update(contact);
        }
        public async Task<List<ContactInfo>> GetAll()
        {
            var result = await _repository.GetAll();
            return _mapper.Map<List<ContactInfo>, List<ContactInfo>>(result);

        }
        public async Task<ContactInfo> Get(Guid id)
        {
            return await _repository.Get(id);
        }

        public async Task Delete(Guid id)
        {
            await _repository.Delete(id);
        }

        
    }
}
