using HelloWorld.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HelloWorld.Fetching
{
    public class GreetingsApiFetcher : IGreetingsFetcher
    {
        private readonly HttpClient _client;
        private readonly IConfigHelper _config;

        public GreetingsApiFetcher(HttpClient client, IConfigHelper config)
        {
            _config = config;
            _client = client;

            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public string Fetch() => Task.Run(FetchAsync).Result;

        private async Task<string> FetchAsync()
        {
            var response = await _client.GetAsync($"{_config.GetBaseUrl()}/hello");
            return response.IsSuccessStatusCode ? await response.Content.ReadAsStringAsync() : null;
        }
    }
}
