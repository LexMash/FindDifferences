using System;

namespace FindDifferences.Infrastracture
{
    public interface IAdsProvider
    {
        event Action AdsShown;
        event Action AdsClosed;
        event Action<bool> AdsCashed;

        void Initialize();
        void CasheAds();
        void ShowAds();
    }
}
