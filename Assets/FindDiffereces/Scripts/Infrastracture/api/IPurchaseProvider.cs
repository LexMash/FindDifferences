using System;

namespace FindDiffereces.Infrastracture
{
    public interface IPurchaseProvider
    {
        event Action<string> PurchaseCompleted;

        void Buy(string purchaseID);
    }
}
