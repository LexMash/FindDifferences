using FindDifferences.GamePlay.Levels;
using FindDifferences.Infrastracture;
using Zenject;

namespace FindDifferences.Installers
{
    public class LevelServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CountdownService>().AsTransient();
            Container.Bind<LevelLoader>().AsSingle();
            Container.BindInterfacesAndSelfTo<LevelController>().AsSingle();
        }
    }
}
