using FindDiffereces.GamePlay.Time;
using FindDiffereces.Infrastracture.DataSystem;
using FindDiffereces.Input;
using FindDifferences.UI;
using Infrastructure;
using StateMachine;

namespace FindDiffereces.GamePlay.FSM.States
{
    public class EndGameState : GameStateBase
    {
        private readonly GameDataProvider _dataProvider;
        private readonly EndGamePopUp _endGamePopUp;
        private readonly ITimeController _timeController;
        private readonly GameInput _gameInput;

        public EndGameState(StateChangeProvider stateChangeProvider) : base(stateChangeProvider)
        {
        }

        public override void Enter()
        {
            base.Enter();

            _gameInput.RestartPerformed += RestartPerformed;

            var endGameData = new EndGameData();
            endGameData.IsWin = _dataProvider.Data.IsWin;
            endGameData.Time = _timeController.CurrentTimeString;

            _endGamePopUp.Show(endGameData);
        }

        public override void Exit()
        {
            base.Exit();

            _gameInput.RestartPerformed -= RestartPerformed;
        }

        private void RestartPerformed()
        {
            var targetState = _dataProvider.Data.IsWin ? GameStateType.LevelLoad : GameStateType.LevelRestart;

            _stateChangeProvider.ChangeState(targetState);
        }
    }
}
