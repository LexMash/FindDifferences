using FindDiffereces.GamePlay.Levels;
using Infrastructure;
using StateMachine;

namespace FindDiffereces.GamePlay.FSM.States
{
    public class RestartLevelState : GameStateBase
    {
        private readonly ILevelController _levelController;

        public RestartLevelState(StateChangeProvider stateChangeProvider) : base(stateChangeProvider)
        {
        }

        public override void Enter()
        {
            base.Enter();

            _levelController.RestartLevel();

            _stateChangeProvider.ChangeState(GameStateType.Wait);
        }
    }
}
