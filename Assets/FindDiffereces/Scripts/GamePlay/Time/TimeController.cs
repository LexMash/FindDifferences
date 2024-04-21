using FindDiffereces.Data;
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
        public string CurrentTimeString { get; private set; } = string.Empty;

        private const string TIME_FORMAT = "{0:00} : {1:00}";
        private const float UPDATE_INTERVAL = 1f;
        private readonly ITimer _timer;
        private readonly TimerWidget _widget;
        private readonly GameConfig _gameConfig;

        private bool _isActive;
        private float _counter;

        public TimeController(ITimer timer, TimerWidget widget, GameConfig gameConfig)
        {
            _timer = timer;
            _widget = widget;
            _gameConfig = gameConfig;

            _timer.TimeOut += OnTimeOut;
        }

        private void OnTimeOut()
        {
            _isActive = false;

            CurrentTimeString = ConvertTimeToString(0f);
            _widget.UpdateView(CurrentTimeString);

            TimeOut?.Invoke();
        }

        public void Start()
        {
            _isActive = true;
            _counter = UPDATE_INTERVAL;

            _timer.Start(_gameConfig.TimeForFindInSeconds);
            CountStart?.Invoke();
        }

        public void Stop()
        {
            _isActive = false;
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
                _counter = UPDATE_INTERVAL;

                CurrentTimeString = ConvertTimeToString(_timer.CurrentTime + 1);

                TimeChanged?.Invoke();
                _widget.UpdateView(CurrentTimeString);
            }
        }

        public void Dispose()
        {
            _timer.TimeOut -= OnTimeOut;
        }

        private string ConvertTimeToString(float time)
        {
            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time % 60);

            return string.Format(TIME_FORMAT, minutes, seconds);
        }
    }
}
