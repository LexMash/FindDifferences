using FindDifferences.GamePlay;
using FindDifferences.GamePlay.Time;
using FindDifferences.UI;
using UnityEngine;
using Zenject;

namespace FindDifferences.Scripts.Installers
{
    public class TimeSystemInstaller : MonoInstaller
    {
        [SerializeField] private TimerWidget _timerWidget;

        public override void InstallBindings()
        {
            Container.Bind<TimerWidget>().FromInstance(_timerWidget).AsSingle();
            Container.BindInterfacesAndSelfTo<TimeController>().AsSingle();
            Container.BindInterfacesAndSelfTo<Timer>().AsTransient();
        }
    }
}
