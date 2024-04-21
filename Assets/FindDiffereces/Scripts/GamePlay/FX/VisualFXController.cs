using FindDifferences.GamePlay;
using FindDifferences.GamePlay.FX;
using System;

namespace FindDiffereces.GamePlay.FX
{
    public class VisualFxController : IDisposable
    {
        private readonly IDifferencesFoundNotifier _differencesNotifier;
        private readonly IGameStateNotifier _gameStateNotifier;

        private readonly IVisualFxSpawnService _spawnService;

        public VisualFxController(
            IVisualFxSpawnService spawnService, 
            IDifferencesFoundNotifier differencesNotifier, 
            IGameStateNotifier gameStateNotifier)
        {
            _spawnService = spawnService;

            _differencesNotifier = differencesNotifier;            
            _differencesNotifier.DifferencesFound += OnDifferencesFound;

            _gameStateNotifier.Won += OnGameWon;
            _gameStateNotifier.Lost += OnGameLost;
            _gameStateNotifier.Restarted += OnGameRestarted;
        }

        public void Dispose()
        {
            _differencesNotifier.DifferencesFound -= OnDifferencesFound;

            _gameStateNotifier.Won -= OnGameWon;
            _gameStateNotifier.Lost -= OnGameLost;
            _gameStateNotifier.Restarted -= OnGameRestarted;
        }

        private void OnDifferencesFound(DifferencesData data)
        {
            foreach (var position in data.Positons)
                _spawnService.ShowTouchFxAt(position);
        }

        private void OnGameWon()
        {
            _spawnService.ShowWinFx();
        }

        private void OnGameLost()
        {
            _spawnService.ShowLostFx();
        }

        private void OnGameRestarted()
        {
            _spawnService.HideAll();
        }
    }
}
