using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Config
{
    [Serializable]
    public class ConfigSettings
    {
        private const string jsonExtension = ".json";
        
#if ODIN_INSPECTOR
        [FilePath]
#endif
        [SerializeField]
        private string _configPath;
        [SerializeField] private PathType _pathType;

        public string ConfigPath
        {
            get
            {
                var configPath = _configPath;
                if (!_configPath.Contains("."))
                {
                    configPath += jsonExtension;
                }
                if (!_configPath.StartsWith("/"))
                {
                    configPath = "/" + configPath;
                }
                return configPath;
            }
        }

        public PathType PathType => _pathType;
        
    }
    
    public enum PathType
    {
        ProjectBuild,
        StreamingAssets,
    }
}