using FindDifferences.GamePlay.Levels;
using FindDifferences.Infrastracture;
using FindDifferences.Infrastracture.DataSystem;
using FindDifferences.GamePlay;
using Infrastructure;
using StateMachine;

namespace FindDifferences.GamePlay.FSM.States
{
    public sealed class LoadLevelState : GameStateBase
    {
        private readonly GameDataProvider _gameDataProvider;
        private readonly LevelLoader _levelLoader;
        private readonly ILevelController _levelController;
        private readonly IAdsProvider _adsProvider;

        public LoadLevelState(
            StateChangeProvider stateChangeProvider,
            GameDataProvider gameDataProvider,
            LevelLoader loader,
            ILevelController levelController,
            IAdsProvider adsProvider
            ) : base(stateChangeProvider)
        {
            _gameDataProvider = gameDataProvider;
            _levelLoader = loader;
            _levelController = levelController;
            _adsProvider = adsProvider;
        }

        public override async void Enter()
        {
            base.Enter();

            int index = _gameDataProvider.Data.CurrentLevelIndex;
            LevelView level = await _levelLoader.LoadLevel(index);
            _levelController.Init(level);
            _adsProvider.CasheAds();

            _stateChangeProvider.ChangeState(GameStateType.Wait);
        }
    }
}
