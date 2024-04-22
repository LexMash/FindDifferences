using FindDifferences.GamePlay.Levels;
using FindDifferences.Infrastracture.api;
using System;

namespace FindDifferences.Infrastracture.DataSystem
{
    public sealed class GameDataProvider : IDisposable, IGameDataChangeNotifier
    {
        public event Action DataChanged;
        public IReadOnlyGameData Data => _gameData;

        private readonly ILevelStateNotifier _levelNotifier;
        private readonly ISaveLoadService _saveLoadService;
        private GameData _gameData;

        public GameDataProvider(ISaveLoadService saveLoadService, ILevelStateNotifier levelNotifier)
        {
            _saveLoadService = saveLoadService;

            _levelNotifier = levelNotifier;
            _levelNotifier.LevelCompleted += OnLevelCompleted;
            _levelNotifier.LevelRestarted += OnLevelRestarted;
            _levelNotifier.LevelChanged += OnLevelChanged;
        }

        public void Initialize()
        {
            _gameData = _saveLoadService.Load();
            DataChanged?.Invoke();
        }

        private void OnLevelRestarted() => SetWin(false);
        private void OnLevelChanged() => SetWin(false);

        private void OnLevelCompleted()
        {
            IncreaseLevel();
            SetWin(true);

            DataChanged?.Invoke();

            _saveLoadService.Save(_gameData);
        }

        private void SetWin(bool isWin)
        {
            _gameData.IsWin = isWin;
        }

        private void IncreaseLevel()
        {
            _gameData.CurrentLevelIndex++;
        }

        public void Dispose()
        {
            _gameData = null;
            _levelNotifier.LevelCompleted -= OnLevelCompleted;
            _levelNotifier.LevelRestarted -= OnLevelRestarted;
        }
    }
}
