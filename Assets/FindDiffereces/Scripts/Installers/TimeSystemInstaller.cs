using FindDiffereces.GamePlay;
using FindDiffereces.GamePlay.Time;
using FindDifferences.UI;
using UnityEngine;
using Zenject;

namespace FindDiffereces.Scripts.Installers
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
