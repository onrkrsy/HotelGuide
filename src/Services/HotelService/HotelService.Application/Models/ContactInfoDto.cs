using HotelService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HotelService.Domain.Enums.ContactInfoType;

namespace HotelService.Application.Models
{
    public class ContactInfoDto 
    {
        public Guid Id { get; set; }
        public Guid HotelId { get; set; }
        public ContactType Type { get; set; }
        public string Content { get; set; }
    }
}
