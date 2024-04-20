using System;

namespace FindDiffereces.GamePlay.Levels
{
    public interface ILevelNotifier
    {
        public event Action LevelCompleted;
        public event Action LevelRestarted;
    }
}