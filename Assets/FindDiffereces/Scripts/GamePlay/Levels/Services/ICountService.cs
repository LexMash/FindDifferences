using System;

namespace FindDifferences.GamePlay.Levels
{
    public interface ICountService
    {
        event Action CountingCompleted;

        void Setup(int targetValue, int step = 1);
        void UpdateCount();
    }
}