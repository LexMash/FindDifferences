using FindDifferences.Factories;
using Zenject;

namespace FindDifferences.Installers
{
    public class GameStateFactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var factory = new GameStateFactory(Container);

            Container.Bind<GameStateFactory>().FromInstance(factory).AsSingle();
        }
    }
}
