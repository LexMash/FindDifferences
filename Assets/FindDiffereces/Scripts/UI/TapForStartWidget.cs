using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace FindDifferences
{
    public class TapForStarIWidget : MonoBehaviour, IPointerClickHandler, ITapForStartInput, ITapForStartWidget
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _appearsTime = 0.5f;

        public event Action TapForStartPressed;

        public void OnPointerClick(PointerEventData eventData)
        {
            TapForStartPressed?.Invoke();
            Hide();
        }

        public void Show()
        {
            BlockRaycastEnable(true);
            _canvasGroup.alpha = 1f;
        }

        private void Hide()
        {
            BlockRaycastEnable(false);
            _canvasGroup.DOFade(0f, _appearsTime);
        }

        private void BlockRaycastEnable(bool isEnable)
        {
            _canvasGroup.interactable = isEnable;
            _canvasGroup.blocksRaycasts = isEnable;
        }
    }
}
