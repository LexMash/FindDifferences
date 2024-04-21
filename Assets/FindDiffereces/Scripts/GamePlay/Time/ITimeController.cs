using System;

namespace FindDiffereces.GamePlay.Time
{
    public interface ITimeController
    {
        event Action TimeChanged;
        event Action TimeOut;
        void AddTime(float time);
        void Start();
    }
}