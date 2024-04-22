using UnityEngine;

namespace FindDifferences.UI
{
    public class UIRoot : MonoBehaviour
    {
        [field: SerializeField] public RectTransform Transform { get; private set; }
    }
}
