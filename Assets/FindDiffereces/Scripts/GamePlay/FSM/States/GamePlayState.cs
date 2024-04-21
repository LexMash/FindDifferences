using FindDiffereces.GamePlay.FX;
using FindDiffereces.GamePlay.Levels;
using FindDiffereces.GamePlay.Time;
using Infrastructure;
using StateMachine;

namespace FindDiffereces.GamePlay.FSM.States
{
    public class GamePlayState : GameStateBase
    {
        private readonly ITimeController _timeController;
        private readonly ILevelController _levelController;
        private readonly IVisualFxController _fxController;

        public GamePlayState(StateChangeProvider stateChangeProvider) : base(stateChangeProvider)
        {
        }

        public override void Enter()
        {
            base.Enter();

            _levelController.LevelCompleted += ChangeState;

            _timeController.Start();
            _timeController.TimeOut += ChangeState;
        }

        public override void Exit() 
        { 
            base.Exit();

            _fxController.HideAllFx();

            _levelController.LevelCompleted -= ChangeState;
            _timeController.TimeOut -= ChangeState;
        }

        private void ChangeState()
        {
            _stateChangeProvider.ChangeState(GameStateType.EndGame);
        }
    }
}
