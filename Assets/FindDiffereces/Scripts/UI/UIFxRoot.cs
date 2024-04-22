using UnityEngine;

namespace FindDifferences.UI
{
    public class UIFxRoot : MonoBehaviour
    {
        [field: SerializeField] public RectTransform Transform { get; private set; }
        [field: SerializeField] public RectTransform EndGameParticlesPosition { get; private set; }
    }
}