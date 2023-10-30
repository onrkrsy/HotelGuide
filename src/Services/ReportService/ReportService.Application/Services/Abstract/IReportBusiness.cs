using ReportService.Application.Models;
using ReportService.Domain.Enitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Application.Services.Abstract
{
    public interface IReportBusiness
    {
 
        Task<Report> Add(CreateReportDto model);
        Task<Report> Update(Report model);
        Task<List<Report>> GetAll();
        Task<Report> Get(Guid id);
        Task Delete(Guid id);
    }
}
