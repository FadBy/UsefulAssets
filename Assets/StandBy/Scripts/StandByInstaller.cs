using Zenject;

namespace StandBy
{
    public class StandByInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IStandByAction>().To<StandBySceneReloadAction>().AsSingle();
            Container.BindInterfacesAndSelfTo<StandByController>().AsSingle();
            Container.BindInterfacesAndSelfTo<StandByOSCReset>().AsSingle();
        }
    }
}