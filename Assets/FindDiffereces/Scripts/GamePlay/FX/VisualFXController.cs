using FindDifferences.GamePlay;
using FindDifferences.GamePlay.FX;
using System;

namespace FindDiffereces.GamePlay.FX
{
    public class VisualFxController : IDisposable, IVisualFxController
    {
        private readonly IDifferencesFoundNotifier _differencesNotifier;
        private readonly IVisualFxSpawnService _spawnService;

        public VisualFxController(
            IVisualFxSpawnService spawnService,
            IDifferencesFoundNotifier differencesNotifier)
        {
            _spawnService = spawnService;

            _differencesNotifier = differencesNotifier;
            _differencesNotifier.DifferencesFound += OnDifferencesFound;
        }

        public void ShowWInFx()
        {
            _spawnService.ShowWinFx();
        }

        public void ShowLostFx()
        {
            _spawnService.ShowLostFx();
        }

        public void HideAllFx()
        {
            _spawnService.HideAll();
        }

        public void Dispose()
        {
            _differencesNotifier.DifferencesFound -= OnDifferencesFound;
        }

        private void OnDifferencesFound(DifferencesData data)
        {
            foreach (var position in data.Positons)
                _spawnService.ShowTouchFxAt(position);
        }
    }
}
