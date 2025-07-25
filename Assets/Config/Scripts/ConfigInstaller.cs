using UnityEngine;
using Zenject;

namespace Config
{
    public class ConfigInstaller : MonoInstaller
    {
        [SerializeField] private ConfigSettings _settings;
        
        public override void InstallBindings()
        {
            Container.Bind<JsonParser>().AsSingle();
            Container.BindInterfacesAndSelfTo<ConfigImporter>().AsSingle();
            Container.Bind<ConfigSettings>().FromInstance(_settings).AsSingle();
        }
    }
}