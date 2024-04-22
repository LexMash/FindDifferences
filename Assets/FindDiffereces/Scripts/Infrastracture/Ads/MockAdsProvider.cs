using System;

namespace FindDifferences.Infrastracture.Ads
{
    public class MockAdsProvider : IAdsProvider
    {
        public event Action AdsShown;
        public event Action AdsClosed;
        public event Action<bool> AdsCashed;

        public MockAdsProvider()
        {

        }

        public void CasheAds()
        {
            
        }

        public void Initialize()
        {
            
        }

        public void ShowAds()
        {
            AdsShown?.Invoke();
        }
    }
}
