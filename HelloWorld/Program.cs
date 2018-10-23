using Autofac;
using HelloWorld.Configuration;
using HelloWorld.Fetching;
using HelloWorld.Logging;
using System;

namespace HelloWorld
{
    class Program
    {
        private static IGreetingsFetcher _greetingsFetcher;
        private static ILogger _logger;

        static void Main(string[] args)
        {
            using (var scope = AutofacConfig.Container.BeginLifetimeScope())
            {
                _logger = scope.Resolve<ILogger>();
                _greetingsFetcher = scope.Resolve<IGreetingsFetcher>();

                var greeting = _greetingsFetcher.Fetch();

                if (greeting == null) throw new ArgumentNullException("Greeting could not be obtained.");

                _logger.Write(greeting);

                Console.WriteLine("Press enter to exit.");
                Console.ReadLine();
            }
        }
    }
}
