using FindDiffereces.GamePlay.Levels;
using FindDiffereces.Infrastracture;
using FindDiffereces.Infrastracture.DataSystem;
using FindDifferences.GamePlay;
using Infrastructure;
using StateMachine;

namespace FindDiffereces.GamePlay.FSM.States
{
    public sealed class LoadLevelState : GameStateBase
    {
        private readonly GameDataProvider _gameDataProvider;
        private readonly LevelLoader _levelLoader;
        private readonly ILevelController _levelController;

        public LoadLevelState(StateChangeProvider stateChangeProvider) : base(stateChangeProvider)
        {
        }

        public override async void Enter()
        {
            base.Enter();

            int index = _gameDataProvider.Data.CurrentLevelIndex;
            LevelView level = await _levelLoader.LoadLevel(index);
            _levelController.Init(level);
            _stateChangeProvider.ChangeState(GameStateType.Wait);
        }
    }
}
