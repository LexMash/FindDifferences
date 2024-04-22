using System;

namespace FindDifferences.GamePlay.Levels
{
    public interface ILevelStateNotifier
    {
        public event Action LevelCompleted;
        public event Action LevelRestarted;
        public event Action LevelChanged;
    }
}