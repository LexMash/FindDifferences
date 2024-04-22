using FindDifferences.Infrastracture.Ads;
using FindDifferences.Infrastracture.Purchase;
using Zenject;

namespace FindDifferences.Installers
{
    public class ThirdPartyServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<UnityIAPurchaseProvider>().AsSingle();
            //Container.BindInterfacesAndSelfTo<AppodealAdsProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<MockAdsProvider>().AsSingle();
        }
    }
}
