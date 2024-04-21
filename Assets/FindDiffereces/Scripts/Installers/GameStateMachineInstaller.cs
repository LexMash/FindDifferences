using Infrastructure;
using Zenject;

namespace FindDiffereces.Installers
{
    public class GameStateMachineInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameStateMachine>().AsSingle().NonLazy();
        }     
    }
}
