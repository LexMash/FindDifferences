using FindDifferences.GamePlay.FX;
using FindDifferences.GamePlay.Time;
using FindDifferences.Input;
using Infrastructure;
using StateMachine;

namespace FindDifferences.GamePlay.FSM.States
{
    public class WaitTapState : GameStateBase
    {
        private readonly GameInput _input;
        private readonly ITimeController _timeController;
        private readonly IVisualFxController _visualFxController;

        public WaitTapState(
            StateChangeProvider stateChangeProvider,
            GameInput input,
            ITimeController timeController,
            IVisualFxController visualFxController
            ) : base(stateChangeProvider)
        {
            _input = input;
            _timeController = timeController;
            _visualFxController = visualFxController;
        }

        public override void Enter()
        {
            base.Enter();
            _timeController.Reset();         
            _visualFxController.HideAllFx();

            _input.StartPerformed += StartPerformed;
        }

        public override void Exit()
        {
            base.Exit();

            _input.StartPerformed -= StartPerformed;
        }

        private void StartPerformed()
        {
            _stateChangeProvider.ChangeState(GameStateType.GamePlay);
        }
    }
}
