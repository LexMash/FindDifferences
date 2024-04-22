using FindDifferences.Factories;
using FindDifferences.GamePlay.FX;
using Zenject;

namespace FindDifferences.Installers
{
    public class FxSystemInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<VisualFxFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<VisualFxSpawnService>().AsSingle();
            Container.BindInterfacesAndSelfTo<VisualFxController>().AsSingle();
        }
    }
}
