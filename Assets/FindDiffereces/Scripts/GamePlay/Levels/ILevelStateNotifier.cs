using System;

namespace FindDiffereces.GamePlay.Levels
{
    public interface ILevelStateNotifier
    {
        public event Action LevelCompleted;
        public event Action LevelRestarted;
    }
}