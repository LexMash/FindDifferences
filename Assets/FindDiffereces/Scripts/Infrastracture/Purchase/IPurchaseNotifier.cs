using System;

namespace FindDiffereces.Infrastracture.Purchase
{
    public interface IPurchaseNotifier
    {
        event Action<string> PurchaseCompleted;
    }
}