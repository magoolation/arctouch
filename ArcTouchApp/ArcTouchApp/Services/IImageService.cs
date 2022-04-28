using System.Threading.Tasks;

namespace ArcTouchApp.Services
{
    public interface IImageService
    {
        Task<string> ResolvePosterImageAsync(string size, string path);
    }
}
