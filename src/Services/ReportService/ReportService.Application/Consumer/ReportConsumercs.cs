using AutoMapper;
using MassTransit;
using ReportService.Application.Services.Abstract;
using ReportService.Application.Services.Concrete;
using ReportService.Infrastructure.Repositories.Concrete;
using ServiceCore.MessageContracts.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ReportService.Application
{
    
    public class ReportConsumer : IConsumer<IReportRequest>
    {
        private readonly IReportBusiness _reportService;

        public ReportConsumer(IReportBusiness reportService)
        {
            _reportService = reportService;
        }
        public async Task Consume(ConsumeContext<IReportRequest> context)
        { 
            await _reportService.Add(new Models.CreateReportDto() { Location = context.Message.Location });
            await Console.Out.WriteLineAsync($"Rapor Oluşturma İsteği Alındı_ {context.Message.Location}");
        }
    }
}
