using FindDifferences.Data;
using FindDifferences.Infrastracture.DataSystem;
using UnityEngine;
using Zenject;

namespace FindDifferences.Installers
{
    public class DataServicesInstaller : MonoInstaller
    {
        [SerializeField] GameConfig _config;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<JsonSaveLoadService>().AsSingle();
            Container.Bind<GameDataProvider>().AsSingle();
            Container.Bind<GameConfig>().FromInstance(_config).AsSingle();
        }
    }
}
