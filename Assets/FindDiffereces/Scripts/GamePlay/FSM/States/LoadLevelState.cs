using FindDifferences.GamePlay.Levels;
using FindDifferences.Infrastracture;
using FindDifferences.Infrastracture.DataSystem;
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
        private readonly ITapForStartWidget _tapForStartWidget;

        public LoadLevelState(
            StateChangeProvider stateChangeProvider,
            GameDataProvider gameDataProvider,
            LevelLoader loader,
            ILevelController levelController,
            IAdsProvider adsProvider,
            ITapForStartWidget tapForStartWidget
            ) : base(stateChangeProvider)
        {
            _gameDataProvider = gameDataProvider;
            _levelLoader = loader;
            _levelController = levelController;
            _adsProvider = adsProvider;
            _tapForStartWidget = tapForStartWidget;
        }

        public override async void Enter()
        {
            base.Enter();

            _tapForStartWidget.Show();

            int index = _gameDataProvider.Data.CurrentLevelIndex;
            LevelView level = await _levelLoader.LoadLevel(index);
            _levelController.Init(level);
            _adsProvider.CasheAds();

            _stateChangeProvider.ChangeState(GameStateType.Wait);
        }
    }
}
