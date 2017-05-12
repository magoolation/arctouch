using System;
using System.Threading.Tasks;
using ArcTouchPOC.DTOS;
using System.Net.Http;
using Newtonsoft.Json;

namespace ArcTouchApp.Repositories
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private HttpClient _client = new HttpClient();

        public async Task<ConfigurationsDTO> GetConfigurationsAsync()
        {
            var url = new Uri($"{Constants.API_URL}/configuration?{Constants.API_KEY}");
            var response = await _client.GetAsync(url);
            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ConfigurationsDTO>(content);
            }
            return null;
        }
    }
}
