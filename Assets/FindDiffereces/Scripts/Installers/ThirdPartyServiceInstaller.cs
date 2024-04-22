using FindDiffereces.Infrastracture.Purchase;
using FindDiffereces.UI;
using FindDifferences.Infrastracture.Ads;
using FindDifferences.Infrastracture.Purchase;
using UnityEngine;
using Zenject;

namespace FindDifferences.Installers
{
    public class ThirdPartyServiceInstaller : MonoInstaller
    {
        [SerializeField] private AdsLogPanel _panel;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<UnityIAPurchaseProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<PuchaseTimeMediator>().AsSingle().NonLazy();

#if UNITY_EDITOR
            var mockAds = new MockAdsProvider(_panel);
            Container.BindInterfacesAndSelfTo<MockAdsProvider>().FromInstance(mockAds).AsSingle();
#elif PLATFORM_ANDROID
            Container.BindInterfacesAndSelfTo<AppodealAdsProvider>().AsSingle();
#endif
        }
    }
}
