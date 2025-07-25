using Newtonsoft.Json;

namespace Config
{
    public class ConfigData
    {
        [JsonProperty("ReceiverPort")]
        public int ReceiverPort { get; private set; }

        [JsonProperty("OSCAddress")]
        public string OSCAddress { get; private set; }

        [JsonProperty("StandByTime")]
        public float StandByTime { get; private set; }
    }
}