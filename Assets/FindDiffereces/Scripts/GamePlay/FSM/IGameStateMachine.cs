using Zenject;

namespace Infrastructure
{
    public interface IGameStateMachine : ITickable
    {
        void SetState(GameStateType type);
    }
}
