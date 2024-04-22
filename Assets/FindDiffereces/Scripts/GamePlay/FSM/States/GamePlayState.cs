using FindDifferences.GamePlay.FX;
using FindDifferences.GamePlay.Levels;
using FindDifferences.GamePlay.Time;
using Infrastructure;
using StateMachine;

namespace FindDifferences.GamePlay.FSM.States
{
    public class GamePlayState : GameStateBase
    {
        private readonly ITimeController _timeController;
        private readonly ILevelStateNotifier _levelStateNotifier;
        private readonly IVisualFxController _fxController;

        public GamePlayState(
            StateChangeProvider stateChangeProvider,
            ITimeController timeController,
            ILevelStateNotifier levelStateNotifier,
            IVisualFxController visualFxController
            ) : base(stateChangeProvider)
        {
            _timeController = timeController;
            _levelStateNotifier = levelStateNotifier;
            _fxController = visualFxController;
        }

        public override void Enter()
        {
            base.Enter();

            _timeController.Start();

            _levelStateNotifier.LevelCompleted += ChangeState;
            _timeController.TimeOut += ChangeState;
        }
         
        public override void Exit() 
        { 
            base.Exit();

            _fxController.HideAllFx();

            _levelStateNotifier.LevelCompleted -= ChangeState;
            _timeController.TimeOut -= ChangeState;
        }

        private void ChangeState()
        {
            _timeController.Stop();

            _stateChangeProvider.ChangeState(GameStateType.EndGame);
        }
    }
}
