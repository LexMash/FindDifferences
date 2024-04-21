using FindDifferences.UI;
using System;
using UnityEngine;
using Zenject;

namespace FindDiffereces.GamePlay.Time
{
    public class TimeController : ITimeController, ITickable, IDisposable, ITimeChangeNotifier
    {
        public event Action CountStart;
        public event Action TimeOut;
        public event Action TimeChanged;      

        private float _updateInterval;
        private const string TIME_FORMAT = "{0:00} : {1:00}";

        private readonly ITimer _timer;
        private readonly TimerWidget _widget;

        private readonly float _mainTimeInterval;

        private bool _isActive;
        private float _counter;

        public TimeController(ITimer timer, TimerWidget widget, float mainTimeInterval, float updateInterval = 1f)
        {
            _timer = timer;
            _widget = widget;
            _mainTimeInterval = mainTimeInterval;
            _updateInterval = updateInterval;

            _timer.TimeOut += OnTimeOut;
        }

        private void OnTimeOut()
        {
            _isActive = false;

            _widget.UpdateView(ConvertTimeToString(0f));

            TimeOut?.Invoke();
        }

        public void Start()
        {
            _isActive = true;
            _counter = _updateInterval;

            _timer.Start(_mainTimeInterval);
            CountStart?.Invoke();
        }

        public void AddTime(float time)
        {
            var newTime = _timer.CurrentTime + time;

            _timer.Start(newTime);
        }

        public void Tick()
        {
            if (!_isActive)
                return;

            var dt = UnityEngine.Time.deltaTime;

            _counter -= dt;
            _timer.Update(dt);

            if (_counter <= 0)
            {
                _counter = _updateInterval;

                var timeToString = ConvertTimeToString(_timer.CurrentTime + 1);

                TimeChanged?.Invoke();
                _widget.UpdateView(timeToString);
            }
        }

        private string ConvertTimeToString(float time)
        {
            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time % 60);

            return string.Format(TIME_FORMAT, minutes, seconds);
        }

        public void Dispose()
        {
            _timer.TimeOut -= OnTimeOut;
        }
    }
}
