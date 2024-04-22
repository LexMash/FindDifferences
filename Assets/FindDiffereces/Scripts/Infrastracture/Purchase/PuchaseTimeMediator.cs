using FindDiffereces.UI;
using FindDifferences.GamePlay.Time;
using FindDifferences.Infrastracture.Purchase;
using System;
using System.Collections.Generic;

namespace FindDiffereces.Infrastracture.Purchase
{
    public class PuchaseTimeMediator : IDisposable
    {
        private readonly IPurchaseNotifier _purchaseNotifier;
        private readonly ITimeController _timeController;
        private readonly PurchaseButton _purchaseButton;
        private readonly Dictionary<string, int> _valueMap = new();

        public PuchaseTimeMediator(IPurchaseNotifier purchaseNotifier, ITimeController timeController, PurchaseButton purchaseButton)
        {
            _purchaseNotifier = purchaseNotifier;
            _timeController = timeController;
            _purchaseButton = purchaseButton;

            _valueMap["more_time"] = 10; //для примера

#if UNITY_EDITOR
            _purchaseNotifier.PurchaseCompleted += PurchaseCompleted;
#elif PLATFORM_ANDROID
            _purchaseButton.PurchaseCompleted += PurchaseCompleted;
#endif            
        }

        private void PurchaseCompleted(string id)
        {
            if(_valueMap.TryGetValue(id, out int value))
            {
                _timeController.AddTime(value);
                return;
            }

            throw new ArgumentException($"Identifier {id} is not contained in the purchase ID map");
        }

        public void Dispose()
        {
#if UNITY_EDITOR
            _purchaseNotifier.PurchaseCompleted -= PurchaseCompleted;
#elif PLATFORM_ANDROID
            _purchaseButton.PurchaseCompleted -= PurchaseCompleted;
#endif
        }
    }
}
