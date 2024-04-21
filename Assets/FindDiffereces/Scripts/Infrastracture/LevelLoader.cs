using FindDiffereces.UI;
using FindDifferences.GamePlay;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace FindDiffereces.Infrastracture
{
    public sealed class LevelLoader
    {
        private readonly IAssetProvider _assetProvider;
        private readonly UIRoot _uiRoot;

        private const string LEVEL_PATH = "Level";

        private int _currentLevelIndex;
        private LevelView _currentLevel;

        private AsyncOperationHandle _asyncHadle;

        public LevelLoader(IAssetProvider assetProvider, UIRoot uiRoot)
        {
            _assetProvider = assetProvider;
            _uiRoot = uiRoot;
        }

        public async Task<LevelView> LoadLevel(int index)
        {
            if (_currentLevel != null)
            {
                if(index == _currentLevelIndex)
                {
                    return _currentLevel;
                }              
                else
                {
                    UnLoadLevelCurrentLevel();
                }
            }

            _currentLevelIndex = index;

            _asyncHadle = Addressables.LoadAssetAsync<GameObject>(LEVEL_PATH + index);

            await _asyncHadle.Task;

            //_currentLevel = Object.Instantiate(_asyncHadle.Task.Result, _uiRoot.Transform).GetComponent<LevelView>();

            return _currentLevel;
        }

        private void UnLoadLevelCurrentLevel()
        {
            Addressables.Release(_asyncHadle);
        }
    }
}
