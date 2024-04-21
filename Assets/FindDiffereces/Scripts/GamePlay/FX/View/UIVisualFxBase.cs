using System;
using UnityEngine;

namespace FindDiffereces.GamePlay.FX
{
    public abstract class UIVisualFxBase : MonoBehaviour
    {
        [field: SerializeField] public FxType Type { get; private set; }
        [SerializeField] private RectTransform _transform;

        public event Action<UIVisualFxBase> Shown;

        public void SetPosition(Vector2 position) 
            => _transform.position = (Vector3)position;

        public abstract void Show();
        public abstract void Hide();
        protected virtual void OnShown() => Shown?.Invoke(this);

        protected virtual void Reset()
        {
            _transform = GetComponent<RectTransform>();
        }
    }
}
