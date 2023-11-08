using HotelService.Application;
using HotelService.Infrastructure;
using HotelService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using ServiceCore.ElasticSearch;
using ServiceCore.Extensions;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddSingleton<IElasticSearch, ElasticSearchManager>();
//builder.Services.AddDbContext<HotelGuideDbContext>(options =>
//{
//    var constr = builder.Configuration?.GetConnectionString("PgSQL");
//    options.UseNpgsql(constr);
//    options.EnableSensitiveDataLogging();
//});
builder.Services.AddAutoMapper(typeof(Program));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Log.Logger = new LoggerConfiguration().WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://localhost:9200"))
{
    AutoRegisterTemplate = true,
    AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv6
})
.CreateLogger();

 
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.ConfigureCustomExceptionMiddleware();
app.UseAuthorization();

app.MapControllers();

app.Run();
