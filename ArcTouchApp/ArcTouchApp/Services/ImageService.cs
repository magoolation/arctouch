using System;
using System.Threading.Tasks;
using ArcTouchApp.Repositories;
using ArcTouchPOC.DTOS;

namespace ArcTouchApp.Services
{
    public class ImageService : IImageService
    {
        private readonly IConfigurationRepository _configurationRepo;
        private ConfigurationsDTO _config;

        public ImageService(IConfigurationRepository configRepo)
        {
            _configurationRepo = configRepo;
        }        

        public async Task<string> ResolvePosterImageAsync(string size, string path)
        {
            if (_config == null)
                _config = await _configurationRepo.GetConfigurationsAsync();
            return $"{_config.images.base_url}/{size}{path}";
        }
    }
}
