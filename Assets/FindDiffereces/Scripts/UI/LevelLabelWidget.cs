using FindDifferences.Infrastracture.DataSystem;
using System;
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

    public class LevelLabelController : IDisposable
    {
        private readonly LevelLabelWidget _widget;
        private readonly IGameDataChangeNotifier _gameDataChangeNotifier;

        public LevelLabelController(LevelLabelWidget widget, IGameDataChangeNotifier gameDataChangeNotifier)
        {
            _widget = widget;
            _gameDataChangeNotifier = gameDataChangeNotifier;

            _gameDataChangeNotifier.DataChanged += OnDataChanged;
        }

        private void OnDataChanged()
        {
            UpdatePanelView();
        }

        private void UpdatePanelView()
        {
            _widget.UpdatePanel("Level " + _gameDataChangeNotifier.Data.CurrentLevelIndex.ToString());
        }

        public void Dispose()
        {
            _gameDataChangeNotifier.DataChanged -= OnDataChanged;
        }
    }
}
