using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace SingletonPattern
{
    public class ContainerConfig
    {
        public static IContainer Configure()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<ConfigurableRecordFinder>();

            var builder = new ContainerBuilder();
            builder.Populate(serviceCollection);
            builder.RegisterType<OrdinaryDatabase>().As<IDatabase>().SingleInstance();
            builder.RegisterType<ConfigurableRecordFinder>();

            return builder.Build();
        }

        public static IServiceProvider ConfigureServiceProvider()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<ConfigurableRecordFinder>();

            var builder = new ContainerBuilder();
            builder.Populate(serviceCollection);
            builder.RegisterType<OrdinaryDatabase>().As<IDatabase>().SingleInstance();

            var container = builder.Build();
            return new AutofacServiceProvider(container);
        }
    }
}
