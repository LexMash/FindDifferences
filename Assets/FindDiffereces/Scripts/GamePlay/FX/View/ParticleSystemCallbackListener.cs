using System;
using UnityEngine;

namespace FindDiffereces.GamePlay.FX.View
{
    public class ParticleSystemCallbackListener : MonoBehaviour
    {
        public event Action Stoped;

        private void OnParticleSystemStopped()
        {
            Stoped?.Invoke();
        }
    }
}
