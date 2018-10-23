using System;
using Microsoft.Extensions.Configuration;

namespace HelloWorld.Configuration
{
    public class ConfigHelper : IConfigHelper
    {
        private readonly IConfiguration _config;

        public ConfigHelper()
        {
            _config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public string GetBaseUrl() =>
            _config.GetSection(ConfigConstants.BaseUrl).Value.ToString();

        public LoggingOption? GetLoggingOption()
        {
            var loggingOptionString = _config.GetSection(ConfigConstants.LoggingOption).Value;

            if (Enum.TryParse(loggingOptionString, out LoggingOption loggingOption))
                return loggingOption;

            return null;
        }

        public FetchingOption? GetFetchingOption()
        {
            var loggingOptionString = _config.GetSection(ConfigConstants.FetchingOption).Value;

            if (Enum.TryParse(loggingOptionString, out FetchingOption fetchingOption))
                return fetchingOption;

            return null;
        }
    }
}
