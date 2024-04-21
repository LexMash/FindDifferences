using System;
using UnityEngine;

namespace FindDifferences.GamePlay
{
    public class LevelView : MonoBehaviour
    {
        [SerializeField] private Differences[] _differences;

        public event Action<DifferencesData> DifferencesFound;
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

        public void Restart()
        {
            foreach (var difference in _differences)
                difference.InteractionEnable(true);
        }


        private void OnDifferenceFound(DifferencesData data)
        {
            DifferencesFound?.Invoke(data);
        }

        private void Reset()
        {
            _differences = GetComponentsInChildren<Differences>();
        }
    }
}
