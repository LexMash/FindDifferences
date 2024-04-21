using FindDiffereces.Input;
using Infrastructure;
using StateMachine;

namespace FindDiffereces.GamePlay.FSM.States
{
    public class WaitTapState : GameStateBase
    {
        private readonly GameInput _input;

        public WaitTapState(StateChangeProvider stateChangeProvider) : base(stateChangeProvider)
        {
        }

        public override void Enter()
        {
            base.Enter();

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
