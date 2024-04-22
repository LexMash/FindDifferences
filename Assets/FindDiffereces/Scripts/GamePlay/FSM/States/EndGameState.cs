using FindDifferences.GamePlay.Time;
using FindDifferences.Infrastracture;
using FindDifferences.Infrastracture.DataSystem;
using FindDifferences.Input;
using FindDifferences.UI;
using Infrastructure;
using StateMachine;

namespace FindDifferences.GamePlay.FSM.States
{
    public class EndGameState : GameStateBase
    {
        private readonly GameDataProvider _dataProvider;
        private readonly EndGamePopUp _endGamePopUp;
        private readonly ITimeController _timeController;
        private readonly GameInput _input;
        private readonly IAdsProvider _adsProvider;

        public EndGameState(
            StateChangeProvider stateChangeProvider,
            GameDataProvider gameDataProvider,
            EndGamePopUp popUp,
            ITimeController timeController,
            GameInput input,
            IAdsProvider adsProvider
            ) : base(stateChangeProvider)
        {
            _dataProvider = gameDataProvider;
            _endGamePopUp = popUp;
            _timeController = timeController;
            _adsProvider = adsProvider;
            _input = input;
        }

        public override void Enter()
        {
            base.Enter();
          
            var endGameData = new EndGameData();
            endGameData.IsWin = _dataProvider.Data.IsWin;
            endGameData.Time = _timeController.CurrentTimeString;
          
            _endGamePopUp.Show(endGameData);

            _input.RestartPerformed += RestartPerformed;
        }

        public override void Exit()
        {
            base.Exit();

            _endGamePopUp.Hide();
            _adsProvider.AdsShown -= AdsShown;
            _input.RestartPerformed -= RestartPerformed;
        }

        private void RestartPerformed()
        {
            _adsProvider.AdsShown += AdsShown;

            _adsProvider.ShowAds();
        }

        private void AdsShown()
        {
            var targetState = _dataProvider.Data.IsWin ? GameStateType.LevelLoad : GameStateType.LevelRestart;

            _stateChangeProvider.ChangeState(targetState);
        }
    }
}
