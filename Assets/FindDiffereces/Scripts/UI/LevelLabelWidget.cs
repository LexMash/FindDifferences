using TMPro;
using UnityEngine;

namespace FindDiffereces.UI
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
