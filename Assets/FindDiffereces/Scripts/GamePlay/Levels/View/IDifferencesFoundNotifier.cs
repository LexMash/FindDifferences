using System;

namespace FindDifferences.GamePlay
{
    public interface IDifferencesFoundNotifier
    {
        event Action<DifferencesData> DifferencesFound;
    }
}