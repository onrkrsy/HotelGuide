using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HotelService.Domain.Enums.ContactInfoType;

namespace HotelService.Application.Models
{
    public class CreateContactInfoDto
    {
        public Guid HotelId { get; set; }
        public ContactType Type { get; set; }
        public string Content { get; set; }
    }
}
