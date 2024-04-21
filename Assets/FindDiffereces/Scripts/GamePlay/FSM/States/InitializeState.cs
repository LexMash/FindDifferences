using FindDiffereces.Infrastracture.DataSystem;
using Infrastructure;
using StateMachine;

namespace FindDifferences.FSM.States
{
    public class InitializeState : GameStateBase
    {
        private readonly GameDataProvider _gameDataProvider;
        
        public InitializeState(StateChangeProvider stateChangeProvider) : base(stateChangeProvider)
        {
        }

        public override void Enter()
        {
            base.Enter();

            _gameDataProvider.Initialize();

            //включение всех занавесок и UI
        }
    }
}
