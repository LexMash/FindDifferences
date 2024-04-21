using FindDiffereces.GamePlay.FSM.States;
using FindDifferences.FSM.States;
using Zenject;

namespace FindDiffereces.Installers
{
    public class GameStatesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<InitializeState>().AsSingle().NonLazy();
            Container.Bind<LoadLevelState>().AsSingle().NonLazy();
            Container.Bind<RestartLevelState>().AsSingle().NonLazy();
            Container.Bind<WaitTapState>().AsSingle().NonLazy();
            Container.Bind<GamePlayState>().AsSingle().NonLazy();
            Container.Bind<EndGameState>().AsSingle().NonLazy();         
        }
    }
}
