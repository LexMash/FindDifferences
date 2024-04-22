using FindDifferences.UI;
using UnityEngine;
using Zenject;

namespace FindDiffereces.Installers
{
    public class LevelUIPanelInstaller : MonoInstaller
    {
        [SerializeField] private LevelLabelWidget _levelLabelWidget;

        public override void InstallBindings()
        {
            Container.Bind<LevelLabelWidget>().FromInstance(_levelLabelWidget).AsSingle();
            Container.BindInterfacesAndSelfTo<LevelLabelController>().AsSingle().NonLazy();
        }
    }
}
