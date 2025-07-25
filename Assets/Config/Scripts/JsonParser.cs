using System.IO;
using Logger;
using Newtonsoft.Json;

namespace Config
{
    public class JsonParser
    {
        public T Parse<T>(string filePath) where T : class
        {
            if (!File.Exists(filePath))
            {
                GameLogger.Instance.LogError("OSC", $"File not found: {filePath}");
                return null;
            }

            string json = File.ReadAllText(filePath);
            var obj = JsonConvert.DeserializeObject<T>(json);
            return obj;
        }
    }
}
