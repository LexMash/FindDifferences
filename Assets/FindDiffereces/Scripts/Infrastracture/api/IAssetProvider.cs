using System.Threading.Tasks;
using UnityEngine;

namespace FindDifferences.Infrastracture
{
    public interface IAssetProvider
    {
        Task<T> Load<T>(string key);
        void UnLoad<T>(T TObject);
    }
}
