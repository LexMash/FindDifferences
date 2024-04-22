using System;

namespace FindDifferences.GamePlay
{
    public interface IGameStateNotifier
    {
        event Action Won;
        event Action Lost;
        event Action Restarted;
    }
}
