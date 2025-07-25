using extOSC;
using UnityEngine;
using Zenject;

namespace OSC
{
    public class OSCInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<OSCListener>().AsSingle();
            Container.Bind<OSCReceiver>().FromComponentInHierarchy().AsSingle();
            Container.Bind<OSCMessageDisplay>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<OSCDebugLogger>().AsSingle();
        }
    }
}