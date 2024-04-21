using FindDiffereces.Factories;
using Zenject;

namespace FindDiffereces.Installers
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
