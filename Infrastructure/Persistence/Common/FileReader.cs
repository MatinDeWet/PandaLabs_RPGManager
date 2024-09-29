using System.Text.Json;

namespace Persistence.Common
{
    internal static class FileReader
    {
        internal static List<T> ReadSeedFile<T>(string fileName)
        {
            var path = Path.Combine(AppContext.BaseDirectory, "Data", "SeedData", fileName);

            var jsonData = File.ReadAllText(path);

            var list = JsonSerializer.Deserialize<List<T>>(jsonData, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return list!;
        }
    }
}
