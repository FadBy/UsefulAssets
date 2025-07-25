using System.IO;
using Logger;
using UnityEngine.Device;
using Zenject;

namespace Config
{
    public class ConfigImporter : IInitializable
    {
        private JsonParser _parser;
        private ConfigSettings _settings;
        
        private ConfigData _configData;

        public ConfigData ConfigData
        {
            get
            {
                InitializeConfig();
                return _configData;
            }
        }

        private string ConfigAbsolutePath
        {
            get
            {
                switch (_settings.PathType)
                {
                    case PathType.ProjectBuild:
                        return Application.dataPath + _settings.ConfigPath;
                    case PathType.StreamingAssets:
                        return Application.streamingAssetsPath + _settings.ConfigPath;
                    default:
                        GameLogger.Instance.LogError("Config", $"Unconsidered PathType: {_settings.PathType}");
                        return "";
                }
            }
        }

        public ConfigImporter(JsonParser parser, ConfigSettings settings)
        {
            _parser = parser;
            _settings = settings;
        }

        public void Initialize()
        {
            InitializeConfig();
        }

        private void InitializeConfig()
        {
            if (_configData != null)
                return;
            
            GameLogger.Instance.LogError("Config", $"Parsing file {ConfigAbsolutePath}");
            _configData = ParseOSCConfig();

            if (_configData == null) return;

            GameLogger.Instance.LogInfo("OSC", $"Parsed ReceiverPort: {_configData.ReceiverPort}");
            GameLogger.Instance.LogInfo("OSC", $"Parsed OSCAddress: {_configData.OSCAddress}");
            GameLogger.Instance.LogInfo("OSC", $"Parsed StandByTime: {_configData.StandByTime}");
        }

        private ConfigData ParseOSCConfig()
        {
            return _parser.Parse<ConfigData>(ConfigAbsolutePath);
        }
    }
}