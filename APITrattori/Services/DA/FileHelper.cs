using APITrattori.Models;
using System.Text.Json;

namespace APITrattori.Services.DA
{
    public static class FileHelper
    {
        
        public static void SerializeAndWrite(List<Trattore> musicInstruments, string path)
        {
            var SerializedList = JsonSerializer.Serialize(musicInstruments);
            File.WriteAllText(path, SerializedList);
        }
        public static IEnumerable<Trattore> ReadAndDeserializeFile(string path)
        {
            var fileContent = File.ReadAllText(path);
            if (fileContent == string.Empty)
            {
                return new List<Trattore>();
            }
            return JsonSerializer.Deserialize<List<Trattore>>(fileContent);
        }
    }
}
