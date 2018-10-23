using Autofac;
using HelloWorld.Fetching;
using HelloWorld.Logging;
using System.Net.Http;

namespace HelloWorld.Configuration
{
    internal class AutofacConfig
    {
        internal static IContainer Container { get; }

        static AutofacConfig()
        {
            var config = new ConfigHelper();

            var builder = new ContainerBuilder();
            builder.RegisterType<HttpClient>().AsSelf();
            builder.RegisterType<ConfigHelper>().AsImplementedInterfaces();

            ResolveLogger(config, builder);
            ResolveFetcher(config, builder);

            Container = builder.Build();
        }

        private static void ResolveFetcher(ConfigHelper config, ContainerBuilder builder)
        {
            switch (config.GetFetchingOption())
            {
                case (FetchingOption.Api):
                    builder.RegisterType<GreetingsApiFetcher>().AsImplementedInterfaces();
                    break;
                default:
                    builder.RegisterType<GreetingsApiFetcher>().AsImplementedInterfaces();
                    break;
            }
        }

        private static void ResolveLogger(ConfigHelper config, ContainerBuilder builder)
        {
            switch (config.GetLoggingOption())
            {
                case (LoggingOption.Console):
                    builder.RegisterType<ConsoleLogger>().AsImplementedInterfaces();
                    break;
                default:
                    builder.RegisterType<ConsoleLogger>().AsImplementedInterfaces();
                    break;
            }
        }
    }
}
