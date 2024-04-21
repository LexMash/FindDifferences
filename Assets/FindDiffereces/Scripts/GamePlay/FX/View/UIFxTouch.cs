using UnityEngine;
using UnityEngine.UI;

namespace FindDiffereces.GamePlay.FX.View
{
    public sealed class UIFxTouch : UIVisualFxBase
    {
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private Image _markImage;

        private void Awake()
        {
            _particleSystem.Stop();
            _markImage.transform.localScale = Vector3.zero;
        }

        public override void Show()
        {
            gameObject.SetActive(true);
            _particleSystem.Play();
        }

        public override void Hide()
        {
            OnShown();
            gameObject.SetActive(false);
        }

        protected override void Reset()
        {
            base.Reset();

            _particleSystem = GetComponentInChildren<ParticleSystem>();
            _markImage = GetComponent<Image>();
        }
    }
}
