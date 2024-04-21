using System;

namespace FindDiffereces.GamePlay
{
    public class Timer : ITimer
    {
        public event Action TimeOut;
        public float CurrentTime => _currentTime;

        private bool _isEnable;
        private float _currentTime;

        public void Start(float startTime)
        {
            _currentTime = startTime;
            _isEnable = true;
        }

        public void Pause()
        {
            _isEnable = false;
        }

        public void UnPause()
        {
            _isEnable = true;
        }

        public void Update(float timeDelta)
        {
            if (!_isEnable)
                return;

            _currentTime -= timeDelta;

            if(_currentTime <= 0)
            {
                _currentTime = 0;
                TimeOut?.Invoke();
                _isEnable = false;             
            }
        }
    }
}
