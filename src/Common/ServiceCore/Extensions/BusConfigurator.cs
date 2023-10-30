using MassTransit;
using MassTransit.Futures.Contracts;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCore.Extensions
{
    public class BusConfigurator
    {
        public static IBusControl ConfigureBus(IConfiguration config,Action<IRabbitMqBusFactoryConfigurator> registrationAction = null)
        { 
            return Bus.Factory.CreateUsingRabbitMq(configuration =>
            {
                configuration.Host($"amqp://{config["RabbitMQ:Host"]}", hostConfiguration =>
                {
                    hostConfiguration.Username(config["RabbitMQ:Username"]);
                    hostConfiguration.Password(config["RabbitMQ:Password"]);
                });

                registrationAction?.Invoke(configuration);
            });
        }
    }
}
