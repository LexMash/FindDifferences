using DG.Tweening;
using FindDiffereces.UI;
using System;
using UnityEngine;

namespace FindDifferences.Infrastracture.Ads
{
    public class MockAdsProvider : IAdsProvider
    {
        private readonly AdsLogPanel _panel;

        public event Action AdsShown;
        public event Action AdsClosed;
        public event Action<bool> AdsCashed;

        public MockAdsProvider(AdsLogPanel panel)
        {
            _panel = panel;
        }

        public void CasheAds()
        {
            _panel.PrintLogMessage("Ads cashing");
            Debug.Log("Ads cashing");
            DOVirtual.DelayedCall(1f, () =>
            {
                _panel.PrintLogMessage("Ads cashed");
                Debug.Log("Ads cashed");
            });
        }

        public void Initialize()
        {
            _panel.PrintLogMessage("Ads service initialized");
            Debug.Log("Ads service initialized");
        }

        public void ShowAds()
        {
            _panel.PrintLogMessage("Ads show");
            Debug.Log("Ads show");
            DOVirtual.DelayedCall(1f, () => AdsShown?.Invoke());
        }
    }
}
