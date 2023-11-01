using MassTransit;
using ReportService.Application;
using ReportService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddMassTransit(x =>
{
     
    x.AddConsumer<ReportConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.ReceiveEndpoint(builder.Configuration["RabbitMQ:QueueName"], e =>
        {
            e.ConfigureConsumer<ReportConsumer>(context);
        });
    });
});

builder.Services.AddScoped<ReportConsumer>();


//var bus = BusConfigurator.ConfigureBus(builder.Configuration, configuration =>
//{
//    configuration.ReceiveEndpoint(builder.Configuration["RabbitMQ:QueueName"].ToString(), e =>
//    {
//        e.Consumer<ReportConsumer>();
//    });
//});
//await bus.StartAsync();



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