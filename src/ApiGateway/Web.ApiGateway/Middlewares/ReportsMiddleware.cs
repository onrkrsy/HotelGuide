using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Ocelot.Infrastructure;
using ServiceCore.Extensions;
using ServiceCore.MessageContracts.Abstract;
using ServiceCore.Models.Abstract;
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;

namespace Web.ApiGateway.Handlers
{
    public class ReportsMiddleware
    { 
        private readonly ISendEndpoint _bus;
        private readonly RequestDelegate _next;
        public ReportsMiddleware(RequestDelegate next,IConfiguration config)
        {
            _next = next;    
            var bus = BusConfigurator.ConfigureBus(config);
            var sendToUri = new Uri($"amqp://{config["RabbitMQ:Host"]}/{config["RabbitMQ:QueueName"]}");
            _bus = bus.GetSendEndpoint(sendToUri).Result;
        }

        public async Task Invoke(HttpContext context, IPublishEndpoint publishEndpoint)
        {
            //CreateReport istediğinin yakalndığı yer
            var _publishEndpoint = publishEndpoint;
            var request = context.Request;
            var body = await new StreamReader(request.Body).ReadToEndAsync();
            await _bus.Send<IReportRequest>(JsonConvert.DeserializeObject<ReportRequest>(body));
            string responseString = "Rapor oluşturma talebi alınmıştır. 'GetAllReports' enpointinden raporun durumu takip edebilirsiniz.";             
            context.Response.ContentType = "text/plain"; 
            context.Response.StatusCode = 200; 
            await context.Response.WriteAsync(responseString);
        }

    }
  
}
