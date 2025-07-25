using System.Linq;
using UnityEngine;
using Zenject;

namespace MenuSystem
{
    public class MenuInstaller : MonoInstaller
    {
        [SerializeField] private MenuSettings _settings;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MenuService>().AsSingle();
            Container.Bind<IMenu>().FromComponentsInHierarchy().AsSingle();
            Container.Bind<MenuSettings>().FromInstance(_settings).AsSingle();
        }
    }
}