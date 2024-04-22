using TMPro;
using UnityEngine;

namespace FindDiffereces.UI
{
    public class AdsLogPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textMesh;

        public void PrintLogMessage(string message)
        {
            _textMesh.text = message;
        }
    }
}
