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
        private readonly ITapForStartWidget _tapForStartWidget;

        public RestartLevelState(
            StateChangeProvider stateChangeProvider,
            IAdsProvider adsProvider,
            ILevelController levelController,
            ITapForStartWidget tapForStartWidget
            ) : base(stateChangeProvider)
        {
            _adsProvider = adsProvider;
            _levelController = levelController;
            _tapForStartWidget = tapForStartWidget;
        }

        public override void Enter()
        {
            base.Enter();

            _tapForStartWidget.Show();

            _levelController.RestartLevel();
            _adsProvider.CasheAds();
            _stateChangeProvider.ChangeState(GameStateType.Wait);
        }
    }
}
