using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Application.Models
{
    public class UpdateHotelDto
    { 
        public string Name { get; set; }
        public string AuthorizedFirstName { get; set; }
        public string AuthorizedLastName { get; set; }
    }
}
