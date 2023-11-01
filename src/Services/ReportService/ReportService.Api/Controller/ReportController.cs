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
        [HttpGet("GetAllReports")]
        public async Task <IActionResult> GetAllReports()
        {
            var reports = await _reportService.GetAll();
            return Ok(reports);
        } 
    }
}
