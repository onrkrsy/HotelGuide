using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using ServiceCore.Extensions;
using Web.ApiGateway.Handlers;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddSingleton<IConfiguration>(builder.Configuration); // IConfiguration'ý servislere ekleyin.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen();
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot(builder.Configuration);
builder.Services.AddMassTransitHostExtension(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseRouting();
app.UseEndpoints(ep => { _ = ep.MapReport("api/CreateReport"); });
app.MapControllers();
await app.UseOcelot();
app.Run();
public static class CustomExtensionMethods
{
    public static IEndpointConventionBuilder MapReport(this IEndpointRouteBuilder endpoints, string pattern)
    { 
        //CreateReport isteðinde çalýþtýrýlacak Middleware
        var pipeline = endpoints.CreateApplicationBuilder()
            .UseMiddleware<ReportsMiddleware>()  
            .Build(); 
        return endpoints.Map(pattern, pipeline);
    }

}