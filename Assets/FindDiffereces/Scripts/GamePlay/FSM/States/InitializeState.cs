using FindDifferences.Factories;
using FindDifferences.Infrastracture;
using FindDifferences.Infrastracture.DataSystem;
using Infrastructure;
using StateMachine;

namespace FindDifferences.FSM.States
{
    public class InitializeState : GameStateBase
    {
        private readonly GameDataProvider _gameDataProvider;
        private readonly IPurchaseProvider _purchaseProvider;
        private readonly IAdsProvider _adsProvider;
        private readonly IVisualFxFactory _visualFxFactory;
        
        public InitializeState(
            StateChangeProvider stateChangeProvider, 
            GameDataProvider gameData, 
            IPurchaseProvider purchaseProvider,
            IAdsProvider adsProvider,
            IVisualFxFactory visualFxFactory
            ) : base(stateChangeProvider)
        {
            _gameDataProvider = gameData;
            _purchaseProvider = purchaseProvider;
            _adsProvider = adsProvider;
            _visualFxFactory = visualFxFactory;
        }

        public override void Enter()
        {
            base.Enter();

            _gameDataProvider.Initialize();
            _purchaseProvider.Initialize();
            _adsProvider.Initialize();
            _visualFxFactory.Initialize();

            //включение всех занавесок и UI
            _stateChangeProvider.ChangeState(GameStateType.LevelLoad);
        }
    }
}
