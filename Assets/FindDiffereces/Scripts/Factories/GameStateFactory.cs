using Infrastructure;
using Zenject;

namespace FindDiffereces.Factories
{
    public class GameStateFactory
    {
        private readonly DiContainer _container;

        public GameStateFactory(DiContainer container)
        {
            _container = container;
        }

        public T CreateState<T>() where T : IGameState
        {
            return _container.Resolve<T>();
        }
    }
}
