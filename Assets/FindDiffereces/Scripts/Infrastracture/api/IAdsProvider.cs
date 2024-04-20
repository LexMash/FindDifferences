using System;

namespace FindDiffereces.Infrastracture
{
    public interface IAdsProvider
    {
        event Action AdsShown;
        event Action AdsClosed;
        event Action<bool> AdsCashed;

        void CasheAds();
        void ShowAds();
    }
}
