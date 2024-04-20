using FindDiffereces.Factories;
using System;
using System.Collections.Generic;
using Zenject;

namespace Infrastructure
{
    public sealed class GameStateMachine : IGameStateMachine, IInitializable, IDisposable
    {
        private readonly GameStateFactory _factory;
        private readonly Dictionary<GameStateType, IGameState> _stateMap = new();
        private IGameState _currentState;

        private bool _isInitialize;

        public GameStateMachine(GameStateFactory factory)
        {
            _factory = factory;
        }

        public void Initialize()
        {


            //TODO создание стейтов

            _isInitialize = true;
        }

        public void SetState(GameStateType type)
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
            if (!_isInitialize)
                return;

            _currentState.Update();
        }

        public void Dispose()
        {
            _currentState = null;

            _stateMap.Clear();
        }
    }
}
