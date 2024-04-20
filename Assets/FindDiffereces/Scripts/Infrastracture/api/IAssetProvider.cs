using System.Threading.Tasks;
using UnityEngine;

namespace FindDiffereces.Infrastracture
{
    public interface IAssetProvider
    {
        Task<T> Load<T>(string key) where T : MonoBehaviour;
        void UnLoad<T>(T TObject) where T : MonoBehaviour;
    }
}
