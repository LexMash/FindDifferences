using FindDifferences.Input;
using FindDifferences.UI;
using UnityEngine;
using Zenject;

namespace FindDifferences.Installers
{
    public class InputInstaller : MonoInstaller
    {
        [SerializeField] private TapForStarIWidget _tapWidget;
        [SerializeField] private EndGamePopUp _popUp;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameInput>().AsSingle();
            Container.BindInterfacesAndSelfTo<TapForStarIWidget>().FromInstance(_tapWidget).AsSingle();
            Container.BindInterfacesAndSelfTo<EndGamePopUp>().FromInstance(_popUp).AsSingle();
        }
    }
}
