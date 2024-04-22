using System;

namespace FindDifferences.GamePlay.Time
{
    public interface ITimeChangeNotifier
    {
        event Action CountStart;
        event Action TimeChanged;
        event Action TimeOut;     
    }
}