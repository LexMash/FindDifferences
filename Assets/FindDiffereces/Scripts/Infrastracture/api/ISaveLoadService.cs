using FindDiffereces.Infrastracture.DataSystem;
using System;

namespace FindDiffereces.Infrastracture.api
{
    public interface ISaveLoadService
    {
        GameData Load();
        void Save(GameData data, Action onSaveCallback = null);
    }
}
