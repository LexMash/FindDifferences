using FindDifferences.GamePlay.Time;
using FindDifferences.Input;
using Infrastructure;
using StateMachine;

namespace FindDifferences.GamePlay.FSM.States
{
    public class WaitTapState : GameStateBase
    {
        private readonly GameInput _input;
        private readonly ITapForStartWidget _tapWidget;
        private readonly ITimeController _timeController;

        public WaitTapState(
            StateChangeProvider stateChangeProvider,
            GameInput input,
            ITapForStartWidget tapWidget,
            ITimeController timeController
            ) : base(stateChangeProvider)
        {
            _input = input;
            _tapWidget = tapWidget;
            _timeController = timeController;
        }

        public override void Enter()
        {
            base.Enter();
            _timeController.Reset();
            _tapWidget.Show();

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
