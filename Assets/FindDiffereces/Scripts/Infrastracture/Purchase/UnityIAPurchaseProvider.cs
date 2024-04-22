using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;
using Product = UnityEngine.Purchasing.Product;

namespace FindDifferences.Infrastracture.Purchase
{
    public class UnityIAPurchaseProvider : IPurchaseProvider, IDetailedStoreListener, IPurchaseNotifier
    {
        public event Action<string> PurchaseCompleted;

        private IStoreController _storeController;

        private const string MORE_TIME = "more_time";

        public void Initialize()
        {
            StandardPurchasingModule.Instance().useFakeStoreAlways = true;
            StandardPurchasingModule.Instance().useFakeStoreUIMode = FakeStoreUIMode.Default;

            var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

            builder.AddProduct(MORE_TIME, ProductType.Consumable);

            UnityPurchasing.Initialize(this, builder);
        }

        public void Buy(string purchaseID = MORE_TIME)
        {
            _storeController.InitiatePurchase(purchaseID);
        }

        public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
        {
            _storeController = controller;
        }

        public void OnInitializeFailed(InitializationFailureReason error)
        {
            OnInitializeFailed(error, null);
        }

        public void OnInitializeFailed(InitializationFailureReason error, string message)
        {
            var errorMessage = $"Purchasing failed to initialize. Reason: {error}.";

            if (message != null)
            {
                errorMessage += $" More details: {message}";
            }

            Debug.Log(errorMessage);
        }

        public void OnPurchaseFailed(Product product, PurchaseFailureDescription failureDescription)
        {
            Debug.Log($"Purchase failed - Product: '{product.definition.id}'," +
                $" Purchase failure reason: {failureDescription.reason}," +
                $" Purchase failure details: {failureDescription.message}");
        }

        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
        {
            var product = purchaseEvent.purchasedProduct;

            Debug.Log($"Purchase Complete - Product: {product.definition.id}");

            PurchaseCompleted?.Invoke(product.definition.id);

            return PurchaseProcessingResult.Complete;
        }

        public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
        {
            Debug.Log($"Purchase failed - Product: '{product.definition.id}', PurchaseFailureReason: {failureReason}");
        }
    }
}
