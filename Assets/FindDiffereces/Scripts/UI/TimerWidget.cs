using TMPro;
using UnityEngine;

namespace FindDifferences.UI
{
    public class TimerWidget : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textMesh;

        public void UpdateView(string timeString)
        {
            _textMesh.text = timeString;
        }
    }
}
