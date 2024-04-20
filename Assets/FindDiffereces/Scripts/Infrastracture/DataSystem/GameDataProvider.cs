using FindDiffereces.GamePlay.Levels;
using FindDiffereces.Infrastracture.api;
using System;

namespace FindDiffereces.Infrastracture.DataSystem
{
    public sealed class GameDataProvider : IDisposable
    {
        public event Action DataChanged;
        public IReadOnlyGameData Data => _gameData;

        private readonly ILevelNotifier _levelNotifier;
        private readonly ISaveLoadService _saveLoadService;
        private GameData _gameData;
     
        public GameDataProvider(ISaveLoadService saveLoadService, ILevelNotifier levelNotifier) 
        {
            _saveLoadService = saveLoadService;
            
            _levelNotifier = levelNotifier;
            _levelNotifier.LevelCompleted += OnLevelCompleted;
            _levelNotifier.LevelRestarted += OnLevelRestarted;
        }

        public void Initialize()
        {
            _gameData = _saveLoadService.Load();
        }

        private void OnLevelRestarted()
        {
            SetWin(false);
        }

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
