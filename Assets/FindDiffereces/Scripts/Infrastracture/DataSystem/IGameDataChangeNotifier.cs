using System;

namespace FindDifferences.Infrastracture.DataSystem
{
    public interface IGameDataChangeNotifier
    {
        IReadOnlyGameData Data { get; }

        event Action DataChanged;
    }
}