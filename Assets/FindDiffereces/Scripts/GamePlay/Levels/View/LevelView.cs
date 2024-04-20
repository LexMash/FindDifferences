using System;
using UnityEngine;

namespace FindDifferences.GamePlay
{
    public class LevelView : MonoBehaviour, IDifferencesFoundNotifier
    {
        [SerializeField] private Differences[] _differences;

        public event Action<DifferencesData> OnDifferencesFound;
        public int DifferencesCount => _differences.Length;

        private void OnEnable()
        {
            foreach (var difference in _differences)
                difference.OnDifferenceFound += OnDifferenceFound;
        }

        private void OnDisable()
        {
            foreach (var difference in _differences)
                difference.OnDifferenceFound -= OnDifferenceFound;
        }

        [ContextMenu("Reload Level")]
        public void Restart()
        {
            foreach (var difference in _differences)
                difference.InteractionEnable(true);
        }


        private void OnDifferenceFound(DifferencesData data)
        {
            OnDifferencesFound?.Invoke(data);
        }

        private void Reset()
        {
            _differences = GetComponentsInChildren<Differences>();
        }
    }
}
