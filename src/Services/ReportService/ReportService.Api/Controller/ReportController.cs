using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReportService.Application.Services.Abstract;

namespace ReportService.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportBusiness _reportService;

        public ReportController(IReportBusiness reportRepository)
        {
            _reportService = reportRepository;
        }
        [HttpGet]
        public IActionResult ListContactInfos()
        {
            var ContactInfos = _reportService.GetAll();
            return Ok(ContactInfos);
        }

    }
}
