using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

namespace FindDiffereces.Infrastracture.Ads
{
    public class AppodealAdsProvider : IAdsProvider, IInterstitialAdListener, IInitializable, IAppodealInitializationListener
    {
#if UNITY_EDITOR && !UNITY_ANDROID && !UNITY_IPHONE
        public static string appKey = "c4afa0f7aa806e2182f39f452beebcdfd59bf469ca433a67";
#elif UNITY_ANDROID
        public static string appKey = "c4afa0f7aa806e2182f39f452beebcdfd59bf469ca433a67";
#elif UNITY_IPHONE
        public static string appKey = "466de0d625e01e8811c588588a42a55970bc7c132649eede";
#else
	    public static string appKey = "";
#endif

        public event Action AdsShown;
        public event Action AdsClosed;
        public event Action<bool> AdsCashed;

        private TextMeshProUGUI _textPanel;

        public AppodealAdsProvider(TextMeshProUGUI textPanel)
        {
            _textPanel = textPanel;
        }

        public void Initialize()
        {
            _textPanel.text = "in Initiolize";

            Appodeal.setLogLevel(Appodeal.LogLevel.Verbose);

            _textPanel.text = "log set";

            Appodeal.setTesting(true);

            _textPanel.text = "test set";

            Appodeal.setUseSafeArea(true);

            _textPanel.text = "unsafe area";

            //Appodeal.setUserId("1");
            //Appodeal.setCustomFilter(UserSettings.USER_AGE, 18);
            //Appodeal.setCustomFilter(UserSettings.USER_GENDER, (int)UserSettings.Gender.MALE);

            _textPanel.text = "set filetrs";

            //Appodeal.setExtraData("testKey", "testValue");
            //Appodeal.resetExtraData("testKey");

            _textPanel.text = "extra data";

            //Appodeal.disableLocationPermissionCheck();
            //Appodeal.setChildDirectedTreatment(false);

            _textPanel.text = "permisison";

            Appodeal.setTriggerOnLoadedOnPrecache(Appodeal.INTERSTITIAL, true);
            Appodeal.setAutoCache(Appodeal.INTERSTITIAL, false);

            _textPanel.text = "INTERSTITIAL";

            //Appodeal.disableNetwork(AppodealNetworks.VUNGLE);
            //Appodeal.disableNetwork(AppodealNetworks.YANDEX, Appodeal.MREC);

            _textPanel.text = "disableNetwork";

            Appodeal.setInterstitialCallbacks(this);

            //Appodeal.setCustomFilter("newBoolean", true);
            //Appodeal.setCustomFilter("newInt", 1234567890);
            //Appodeal.setCustomFilter("newDouble", 123.123456789);
            //Appodeal.setCustomFilter("newString", "newStringFromSDK");

            _textPanel.text = "custom callback";

            Appodeal.initialize(appKey, Appodeal.INTERSTITIAL, null);
            _textPanel.text = "end Initiolize";
        }

        public void CasheAds()
        {
            _textPanel.text = "Ads cahed start";
            Appodeal.cache(Appodeal.INTERSTITIAL);
        }

        public void ShowAds()
        {
            if (Appodeal.isLoaded(Appodeal.INTERSTITIAL) && Appodeal.canShow(Appodeal.INTERSTITIAL, "default") && !Appodeal.isPrecache(Appodeal.INTERSTITIAL))
            {
                _textPanel.text = "Ads show";
                Appodeal.show(Appodeal.INTERSTITIAL);
            }
            else
            {
                Debug.Log("Interstitial Not Cashed");
            }
        }

        public void onInterstitialClicked()
        {
            Debug.Log("InterstitialClicked");
        }

        public void onInterstitialClosed()
        {
            Debug.Log("Interstitial Closed");
            //AdsClosed?.Invoke();
        }

        public void onInterstitialExpired()
        {
            Debug.Log("Interstitial Expired");
        }

        public void onInterstitialFailedToLoad()
        {
            Debug.Log("Interstitial Failed Load");
        }

        public void onInterstitialLoaded(bool isPrecache)
        {
            Debug.Log("Interstitial Loaded");
            _textPanel.text = "Interstitial Loaded";
            //AdsCashed?.Invoke(isPrecache);
        }

        public void onInterstitialShowFailed()
        {
            Debug.Log("Interstitial Show Failed");
        }

        public void onInterstitialShown()
        {
            Debug.Log("Interstitial Shown");
            _textPanel.text = "Interstitial Shown";
            //AdsShown?.Invoke();
        }

        public void onInitializationFinished(List<string> errors)
        {
            _textPanel.text = errors[0];

            string output = errors == null ? string.Empty : string.Join(", ", errors);
            Debug.Log($"onInitializationFinished(errors:[{output}])");

            Debug.Log($"isAutoCacheEnabled() for banner: {Appodeal.isAutoCacheEnabled(Appodeal.BANNER)}");
            Debug.Log($"isInitialized() for banner: {Appodeal.isInitialized(Appodeal.BANNER)}");
            Debug.Log($"isSmartBannersEnabled(): {Appodeal.isSmartBannersEnabled()}");
            Debug.Log($"getUserId(): {Appodeal.getUserId()}");
            Debug.Log($"getSegmentId(): {Appodeal.getSegmentId()}");
            Debug.Log($"getRewardParameters(): {Appodeal.getRewardParameters()}");
            Debug.Log($"getNativeSDKVersion(): {Appodeal.getNativeSDKVersion()}");

            var networksList = Appodeal.getNetworks(Appodeal.REWARDED_VIDEO);
            output = networksList == null ? string.Empty : string.Join(", ", (networksList.ToArray()));
            Debug.Log($"getNetworks() for RV: {output}");

            var additionalParams = new Dictionary<string, string> { { "key1", "value1" }, { "key2", "value2" } };

            var purchase = new PlayStoreInAppPurchase.Builder(Appodeal.PlayStorePurchaseType.Subs)
                .withAdditionalParameters(additionalParams)
                .withPurchaseTimestamp(793668600)
                .withDeveloperPayload("payload")
                .withPurchaseToken("token")
                .withPurchaseData("data")
                .withPublicKey("key")
                .withSignature("signature")
                .withCurrency("USD")
                .withOrderId("orderId")
                .withPrice("1.99")
                .withSku("sku")
                .build();

            Appodeal.validatePlayStoreInAppPurchase(purchase, null);

            Appodeal.logEvent("test_event", new Dictionary<string, object> { { "test_key_1", 42 }, { "test_key_2", "test_value" } });
        }
    }
}
