using MassTransit;
using ServiceCore.Extensions;
using ServiceCore.MessageContracts;
using ReportService.Infrastructure;
using ReportService.Application;
using ReportService.Application.Services.Concrete;
using static MassTransit.Logging.OperationName;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructureServices(builder.Configuration);

var bus = BusConfigurator.ConfigureBus(builder.Configuration,configuration =>
{ 
    configuration.ReceiveEndpoint(builder.Configuration["RabbitMQ:QueueName"].ToString(), e =>
    {
        e.Consumer<ReportConsumer>();
    });
});

await bus.StartAsync(); 
var app = builder.Build(); 
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();