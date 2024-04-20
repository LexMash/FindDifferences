using System;
using System.Collections.Generic;

namespace Infrastructure
{
    public class GameStateMachine : IGameStateMachine, IDisposable
    {      
        private readonly Dictionary<GameStateType, IGameState> _stateMap = new();
        private IGameState _currentState;

        public GameStateMachine(IGameState state)
        {
        }

        public virtual void SetState(GameStateType type)
        {
            if(_stateMap.TryGetValue(type, out IGameState state))
            {
                _currentState?.Exit();

                _currentState = state;

                _currentState.Enter();
            }
            else
            {
                throw new StateMachineException("StateMachine doesn't have this type of state");
            }
        }

        public void Tick()
        {
            _currentState?.Update();
        }

        public void Dispose()
        {
            _currentState = null;

            _stateMap.Clear();
        }

        protected class StateMachineException : SystemException
        {
            public StateMachineException(string message) : base(message)
            {
            }
        }
    }
}
