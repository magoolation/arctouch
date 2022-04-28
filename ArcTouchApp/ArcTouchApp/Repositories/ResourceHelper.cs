using System.IO;
using System.Reflection;

namespace ArcTouchApp.Repositories
{
    public class ResourceHelper
    {
        public static string LoadFile(string filename)
        {
            var assembly = typeof(ResourceHelper).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream($"ArcTouchApp.SampleData.{filename}");
            string text = "";
            using (var reader = new StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }
            return text;
        }
    }
}