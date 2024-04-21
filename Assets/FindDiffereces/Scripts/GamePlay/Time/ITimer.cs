using System;

namespace FindDiffereces.GamePlay
{
    public interface ITimer
    {
        event Action TimeOut;

        float CurrentTime { get; }

        void Start(float startTime);
        void Pause();
        public void UnPause();
        void Update(float timeDelta);
    }
}