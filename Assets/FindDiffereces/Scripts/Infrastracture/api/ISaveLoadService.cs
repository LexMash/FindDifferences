using FindDifferences.Infrastracture.DataSystem;
using System;

namespace FindDifferences.Infrastracture.api
{
    public interface ISaveLoadService
    {
        GameData Load();
        void Save(GameData data, Action onSaveCallback = null);
    }
}
