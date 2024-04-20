using AppodealAds.Unity.Api;
using FindDiffereces.Infrastracture.Ads;
using FindDiffereces.Infrastracture.Purchase;
using TMPro;
using UnityEngine;

namespace FindDifferences
{
    public class ForTest : MonoBehaviour
    {
        public TextMeshProUGUI _mesh;
        // Start is called before the first frame update
        AppodealAdsProvider purchaseProvider;

        void Start()
        {
            _mesh.text = "start";
            purchaseProvider = new AppodealAdsProvider(_mesh);
            purchaseProvider.Initialize();
            purchaseProvider.CasheAds();
            purchaseProvider.AdsCashed += PurchaseProvider_AdsCashed;
        }

        private void PurchaseProvider_AdsCashed(bool obj)
        {
            purchaseProvider.ShowAds();
        }

        // Update is called once per frame
        //void Update()
        //{
        //    if (Input.GetKeyDown(KeyCode.Space))
        //    {
        //        purchaseProvider.ShowAds();
        //    }
        //}
    }
}
