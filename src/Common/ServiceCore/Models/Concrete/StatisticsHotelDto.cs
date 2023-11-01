using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCore.Models.Concrete
{
    public class StatisticsHotelDto
    { 
        public string Location { get; set; }
        public int HotelCount { get; set; }
        public int ConnectionCount { get; set;}
    }
}
