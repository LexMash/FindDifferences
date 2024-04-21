using System;

namespace FindDiffereces.GamePlay.Time
{
    public interface ITimeChangeNotifier
    {
        event Action CountStart;
        event Action TimeChanged;
        event Action TimeOut;     
    }
}