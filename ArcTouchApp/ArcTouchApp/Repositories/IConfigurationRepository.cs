using ArcTouchPOC.DTOS;
using System.Threading.Tasks;

namespace ArcTouchApp.Repositories
{
    public interface IConfigurationRepository
    {
        Task<ConfigurationsDTO> GetConfigurationsAsync();
    }
}
