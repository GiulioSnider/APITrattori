using APITrattori.Models;
using System.Text.Json;

namespace APITrattori.Services.DA
{
    public static class FileHelper
    {
        private static string _path = "File\\Trattori.txt";
        public static void SerializeAndWrite(List<Trattore> musicInstruments)
        {
            var SerializedList = JsonSerializer.Serialize(musicInstruments);
            File.WriteAllText(_path, SerializedList);
        }
        public static IEnumerable<Trattore> ReadAndDeserializeFile()
        {
            var fileContent = File.ReadAllText(_path);
            if (fileContent == string.Empty)
            {
                return new List<Trattore>();
            }
            return JsonSerializer.Deserialize<List<Trattore>>(fileContent);
        }
    }
}
