using MassTransit;
using Microsoft.Extensions.Logging;
using ServiceCore.MessageContracts.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Infrastructure.Consumer
{
    public class CreateReportConsumer : IConsumer<IReportRequest>
    {
        private ILogger<CreateReportConsumer> _logger;  

        public CreateReportConsumer(ILogger<CreateReportConsumer> logger)
        {
            _logger = logger; 
        }

        public async Task Consume(ConsumeContext<IReportRequest> context)
        { 
            _logger.LogInformation("Starting prepare report data process");
            var data = context.Message.Data;
            //Create report
            //await _reportService.CreateReport(); 

            _logger.LogInformation("Process has been finished succesfully");

        }
    }
}
