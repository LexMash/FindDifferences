using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace FindDiffereces.GamePlay.FX.View
{
    public sealed class UIFxTouch : UIVisualFxBase
    {
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private Image _markImage;
        [SerializeField] private float _animationTime = 0.3f;
        [SerializeField] private Ease _animationEase;

        private Tweener _bounceTween;

        private void Awake()
        {
            _bounceTween.SetAutoKill(false);
            _markImage.transform.localScale = Vector3.zero;
        }

        public override void Show()
        {
            _markImage.transform.localScale = Vector3.zero;
            gameObject.SetActive(true);
            _particleSystem.Play();
            _bounceTween = _markImage.transform.DOScale(Vector2.one, _animationTime).SetEase(_animationEase);
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
            _markImage = GetComponentInChildren<Image>();
        }

        private void OnDestroy()
        {
            _bounceTween.Kill();
        }
    }
}
