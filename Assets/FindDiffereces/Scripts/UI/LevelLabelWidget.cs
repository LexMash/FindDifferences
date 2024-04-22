using TMPro;
using UnityEngine;

namespace FindDifferences.UI
{
    public class LevelLabelWidget : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _testMesh;

        public void UpdatePanel(string text)
        {
            _testMesh.text = text;
        }
    }
}
