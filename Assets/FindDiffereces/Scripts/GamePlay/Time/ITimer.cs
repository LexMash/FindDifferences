using System;

namespace FindDiffereces.GamePlay
{
    public interface ITimer
    {
        event Action TimeOut;

        float CurrentTime { get; }

        void Start(float startTime);
        void Update(float timeDelta);
    }
}