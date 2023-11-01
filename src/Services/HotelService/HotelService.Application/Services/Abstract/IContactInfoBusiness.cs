using HotelService.Application.Models;
using HotelService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Application.Services.Abstract
{
    public interface IContactInfoBusiness
    {
        Task<ContactInfo> Add(CreateContactInfoDto model);
        Task<ContactInfo> Update(UpdateContactInfoDto model);
        Task<List<ContactInfo>> GetAll();
        Task<ContactInfo> Get(Guid id);
        Task Delete(Guid id);

    }

   
}
