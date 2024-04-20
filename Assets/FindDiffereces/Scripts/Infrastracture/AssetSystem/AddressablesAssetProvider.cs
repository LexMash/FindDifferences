using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace FindDiffereces.Infrastracture.AssetSystem
{
    public sealed class AddressablesAssetProvider : IAssetProvider
    {
        public async Task<T> Load<T>(string key) where T : MonoBehaviour
        {
            return await Addressables.LoadAssetAsync<T>(key).Task;
        }

        public void UnLoad<T>(T TObject) where T : MonoBehaviour
        {
            Addressables.Release(TObject);
        }
    }
}
