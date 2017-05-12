using System;
using System.Threading.Tasks;
using ArcTouchPOC.DTOS;
using Newtonsoft.Json;
using PCLStorage;

namespace ArcTouchApp.Repositories
{
    public class MockConfigurationRepository : IConfigurationRepository
    {
        public async Task<ConfigurationsDTO> GetConfigurationsAsync()
        {
            string content = ResourceHelper.LoadFile("configuration.json");
            return JsonConvert.DeserializeObject<ConfigurationsDTO>(content);
        }
    }
}
