using FindDifferences.UI;
using FindDifferences.GamePlay;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace FindDifferences.Infrastracture
{
    public sealed class LevelLoader
    {
        private readonly UIRoot _uiRoot;

        private const string LEVEL_PATH = "Level";

        private int _currentLevelIndex;
        private LevelView _currentLevel;

        private AsyncOperationHandle<GameObject> _asyncHadle;

        public LevelLoader(UIRoot uiRoot)
        {
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

            _asyncHadle = Addressables.LoadAssetAsync<GameObject>(LEVEL_PATH + 0); //всегда загружаем 1 уровень для тестов

            await _asyncHadle.Task;

            _currentLevel = Object.Instantiate(_asyncHadle.Result, _uiRoot.Transform).GetComponent<LevelView>();

            return _currentLevel;
        }

        private void UnLoadLevelCurrentLevel()
        {           
            Object.Destroy(_currentLevel.gameObject);
            Addressables.Release(_asyncHadle);
        }
    }
}
