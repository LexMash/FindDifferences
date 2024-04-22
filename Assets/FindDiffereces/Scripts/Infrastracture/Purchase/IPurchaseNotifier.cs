using System;

namespace FindDifferences.Infrastracture.Purchase
{
    public interface IPurchaseNotifier
    {
        event Action<string> PurchaseCompleted;
    }
}