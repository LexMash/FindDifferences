using FindDifferences.UI;
using UnityEngine;
using Zenject;

namespace FindDifferences.Installers
{
    public class UIRootsInstaller : MonoInstaller
    {
        [SerializeField] private UIRoot _uiRoot;
        [SerializeField] private UIFxRoot _uiFxRoot;

        public override void InstallBindings()
        {
            Container.Bind<UIRoot>().FromInstance(_uiRoot).AsSingle();
            Container.Bind<UIFxRoot>().FromInstance(_uiFxRoot).AsSingle();
        }
    }
}
