using System;

namespace FindDiffereces.GamePlay
{
    public class Timer : ITimer
    {
        public event Action TimeOut;
        public float CurrentTime => _currentTime;

        private float _currentTime;

        public void Start(float startTime)
        {
            _currentTime = startTime;
        }

        public void Update(float timeDelta)
        {
            _currentTime -= timeDelta;

            if(_currentTime <= 0)
            {
                _currentTime = 0;
                TimeOut?.Invoke();            
            }
        }
    }
}
