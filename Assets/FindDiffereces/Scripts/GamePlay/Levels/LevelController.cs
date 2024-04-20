﻿using FindDifferences.GamePlay;
using System;

namespace FindDiffereces.GamePlay.Levels
{
    public class LevelController : ILevelController, IDisposable
    {
        public event Action LevelCompleted;
        public event Action LevelRestarted;

        private readonly ICountService _countService;

        private LevelView _currentLevel;

        public LevelController(ICountService countService)
        {
            NullCheck(countService);

            _countService = countService;
            _countService.CountingCompleted += OnCountingCompleted;
        }

        public void SetLevel(LevelView level)
        {
            NullCheck(level);

            if (_currentLevel != level && _currentLevel)
                _currentLevel.OnDifferencesFound -= OnDifferenesFound;

            if (_currentLevel == level)
            {
                _countService.Setup(_currentLevel.DifferencesCount);
                return;
            }              

            _currentLevel = level;

            _currentLevel.OnDifferencesFound += OnDifferenesFound;

            _countService.Setup(_currentLevel.DifferencesCount);
        }

        private void OnCountingCompleted()
        {
            LevelCompleted?.Invoke();
        }

        private void OnDifferenesFound(DifferencesData data)
        {
            _countService.UpdateCount();
        }

        public void RestartLevel()
        {
            _currentLevel?.Restart();
            LevelRestarted?.Invoke();
        }

        public void Dispose()
        {
            _countService.CountingCompleted -= OnCountingCompleted;
            _currentLevel.OnDifferencesFound -= OnDifferenesFound;
            _currentLevel = null;
        }

        private static void NullCheck<T>(T TClass) where T : class
        {
            if (TClass == null)
                new ArgumentNullException($"The LevelController cannot depends on NULL {typeof(T)}");
        }
    }
}
