using System;

namespace FindDifferences.Infrastracture
{
    public interface IPurchaseProvider
    {
        void Initialize();
        void Buy(string purchaseID);
    }
}
