using UnityEngine;
using UnityEngine.UI;

namespace FindDiffereces.UI
{
    public class BackGroundWidget : MonoBehaviour
    {
        [SerializeField] private RawImage _rawImage;
        [SerializeField] private float _scrollSpeed;
        [SerializeField] private Vector2 _scrollDirection;

        private void Update()
        {
            _rawImage.uvRect = new Rect(_rawImage.uvRect.position + _scrollDirection.normalized * _scrollSpeed * Time.deltaTime, _rawImage.uvRect.size);
        }
    }
}
