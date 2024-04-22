using FindDifferences;
using FindDifferences.UI;
using System;

namespace FindDifferences.Input
{
    public sealed class GameInput : IDisposable
    {
        public event Action StartPerformed;
        public event Action RestartPerformed;

        private readonly ITapForStartInput _startInput;
        private readonly IRestartInput _restartInput;
        
        public GameInput(ITapForStartInput startInput, IRestartInput restartInput)
        {
            _startInput = startInput;
            _restartInput = restartInput;

            _startInput.TapForStartPressed += StartPressed;
            _restartInput.RestartPressed += RestartPressed;
        }

        private void StartPressed() => StartPerformed?.Invoke();
        private void RestartPressed() => RestartPerformed?.Invoke();

        public void Dispose()
        {
            _startInput.TapForStartPressed -= StartPressed;
            _restartInput.RestartPressed -= RestartPressed;
        }
    }
}
