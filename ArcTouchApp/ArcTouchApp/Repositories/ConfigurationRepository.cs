using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using ModernHttpClient;
using ArcTouchApp.DTOS;

namespace ArcTouchApp.Repositories
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private readonly ITheMovieDatabaseRepository _repository;

        public ConfigurationRepository(ITheMovieDatabaseRepository repository)
        {
            _repository = repository;
        }

        public async Task<ConfigurationsDTO> GetConfigurationsAsync()
        {
            return await _repository.GetAPIConfigurationsAsync(Constants.API_KEY);
        }
    }
}
