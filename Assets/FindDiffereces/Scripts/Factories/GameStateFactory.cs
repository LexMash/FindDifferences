using Infrastructure;

namespace FindDiffereces.Factories
{
    public class GameStateFactory
    {
        private readonly DIContainer _container;

        public GameStateFactory(DIContainer container)
        {
            _container = container;
        }

        public T CreateState<T>() where T : IGameState
        {
            return _container.Resolve<T>();
        }
    }
}
