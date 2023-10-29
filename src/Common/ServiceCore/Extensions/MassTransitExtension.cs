using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceCore.Extensions
{
    public static class MasstransitExtension
    {
        public static void AddMassTransitConsumerExtension<TConsumer>(this IServiceCollection services, IConfiguration configuration)
         where TConsumer : class, IConsumer
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumer<TConsumer>();
                x.SetKebabCaseEndpointNameFormatter();
                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host(configuration.GetConnectionString("RabbitMq"));
                    cfg.UseDelayedMessageScheduler();
                    cfg.ReceiveEndpoint(typeof(TConsumer).Name, ep =>
                    {
                        ep.PrefetchCount = 1;
                        ep.UseMessageRetry(r => r.Interval(5, 1000));
                        ep.ConfigureConsumer<TConsumer>(provider);
                    });
                }));
            });
        }
    }
}
