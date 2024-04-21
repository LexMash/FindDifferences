using System;

namespace FindDiffereces.GamePlay.Time
{
    public interface ITimeController
    {
        event Action CountStart;
        event Action TimeChanged;
        event Action TimeOut;

        public string CurrentTimeString { get; }
        void AddTime(float time);
        void Start();
        void Stop();
    }
}