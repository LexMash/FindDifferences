using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace FindDifferences.GamePlay
{
    public class DifferenceButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Image _image;

        public Vector2 Position => _image.rectTransform.position;

        public event Action OnDifferenceClicked;

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("button " + Position);
            OnDifferenceClicked?.Invoke();
        }

        public void InteractionEnable(bool isEnable) 
            => _image.enabled = isEnable;

        private void Reset()
        {
            _image = GetComponent<Image>();
        }
    }
}
