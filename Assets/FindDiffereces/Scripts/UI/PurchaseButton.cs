using System;
using UnityEngine;
using UnityEngine.UI;

namespace FindDiffereces.UI
{
    /// <summary>
    /// так как в билде не работает UnityIAP в тестовом режиме - подставляем костыль
    /// </summary>
    public class PurchaseButton : MonoBehaviour
    {
        [SerializeField] private Button _bttn;

        public event Action<string> PurchaseCompleted;

        private void OnEnable()
        {
            _bttn.onClick.AddListener(BttnClicked);
        }

        private void OnDisable()
        {
            _bttn.onClick.RemoveListener(BttnClicked);
        }

        private void BttnClicked()
        {
            PurchaseCompleted?.Invoke("more_time");
        }
    }
}
