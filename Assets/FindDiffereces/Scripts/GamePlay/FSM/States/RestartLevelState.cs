using FindDifferences.GamePlay.Levels;
using FindDifferences.Infrastracture;
using Infrastructure;
using StateMachine;

namespace FindDifferences.GamePlay.FSM.States
{
    public class RestartLevelState : GameStateBase
    {
        private readonly ILevelController _levelController;
        private readonly IAdsProvider _adsProvider;

        public RestartLevelState(StateChangeProvider stateChangeProvider) : base(stateChangeProvider)
        {
        }

        public override void Enter()
        {
            base.Enter();

            _levelController.RestartLevel();
            _adsProvider.CasheAds();
            _stateChangeProvider.ChangeState(GameStateType.Wait);
        }
    }
}
