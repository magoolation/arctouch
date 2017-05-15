using System.Threading.Tasks;
using Newtonsoft.Json;
using ArcTouchApp.DTOS;

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
