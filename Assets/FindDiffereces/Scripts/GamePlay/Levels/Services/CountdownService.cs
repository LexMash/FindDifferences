using System;

namespace FindDifferences.GamePlay.Levels
{
    public class CountdownService : ICountService
    {
        public event Action CountingCompleted;

        private int _targetValue;
        private int _step;

        public void Setup(int targetValue, int step = 1)
        {
            _targetValue = targetValue;
            _step = step;
        }

        public void UpdateCount()
        {
            _targetValue -= _step;

            if(_targetValue == 0)
            {
                CountingCompleted?.Invoke();

                _targetValue = 0;
                _step = 0;
            }
        }
    }
}