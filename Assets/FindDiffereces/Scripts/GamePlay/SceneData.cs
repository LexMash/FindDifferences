using UnityEngine;

namespace FindDifferences.GamePlay
{
    public class SceneData : MonoBehaviour
    {
        [field: SerializeField] public RectTransform FxCanvas { get; private set; }
        [field: SerializeField] public RectTransform PopUpCanvas { get; private set; }
        [SerializeField] private RectTransform _endGameParticlesTransform;

        public Vector2 EndGameParticlesPosition => _endGameParticlesTransform.anchoredPosition;
    }
}
