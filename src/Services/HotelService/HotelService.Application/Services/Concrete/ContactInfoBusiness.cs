using AutoMapper;
using HotelService.Application.Models;
using HotelService.Application.Services.Abstract;
using HotelService.Domain.Entities;
using HotelService.Infrastructure.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Application.Services.Concrete
{
    public class ContactInfoBusiness : IContactInfoBusiness
    {
        IContactInfoRepository _repository;
     
        public ContactInfoBusiness(IContactInfoRepository repository) 
        { 
            _repository = repository;
        }
        public async Task<ContactInfo> Add(CreateContactInfoDto model)
        {
            var contact = new ContactInfo() { Content = model.Content, HotelId = model.HotelId, Type = model.Type  };
            contact.Id = new Guid();
            return await _repository.Create(contact);
        }
        public async Task<ContactInfo> Update(UpdateContactInfoDto model)
        {
            var contact = new ContactInfo() { Content = model.Content, HotelId = model.HotelId, Type = model.Type  };
            return await _repository.Update(contact);
        }
        public async Task<List<ContactInfo>> GetAll()
        {
            var result = await _repository.GetAll();
            return result;

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
