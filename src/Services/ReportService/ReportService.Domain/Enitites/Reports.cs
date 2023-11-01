using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportService.Domain.Enums;

namespace ReportService.Domain.Enitites
{
    public class Report
    { 
            [Key] 
            public Guid Id { get; set; }

            [Required]
            public DateTime RequestedAt { get; set; }

            [Required]
            public ReportStatus Status { get; set; }
            public string Location { get; set; }
            public int TotalHotels { get; set; }
            public int TotalPhoneNumbers { get; set; }
 
    }
}
