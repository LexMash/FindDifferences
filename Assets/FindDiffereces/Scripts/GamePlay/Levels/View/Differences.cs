using System;
using UnityEngine;

namespace FindDifferences.GamePlay
{
    public class Differences : MonoBehaviour
    {
        [SerializeField] private DifferenceButton[] _buttons;

        public event Action<DifferencesData> OnDifferenceFound;

        private void OnEnable()
        {
            foreach(var button in _buttons)
                button.OnDifferenceClicked += OnDifferenceClicked;
        }

        private void OnDisable()
        {
            foreach (var button in _buttons)
                button.OnDifferenceClicked -= OnDifferenceClicked;
        }

        public void InteractionEnable(bool isEnable)
        {
            foreach (var button in _buttons)
                button.InteractionEnable(isEnable);
        }

        private void OnDifferenceClicked()
        {
            DifferencesData data = new();
            FillDifferenceData(ref data);

            OnDifferenceFound?.Invoke(data);

            InteractionEnable(false);
        }

        private void FillDifferenceData(ref DifferencesData data)
        {
            data.Positons = new Vector2[_buttons.Length];

            for (int i = 0; i < _buttons.Length; i++)
            {
                data.Positons[i] = _buttons[i].Position;
            }
        }
    }
}
