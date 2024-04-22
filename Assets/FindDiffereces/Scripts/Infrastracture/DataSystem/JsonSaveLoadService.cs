using FindDifferences.Infrastracture.api;
using Newtonsoft.Json;
using System;
using System.IO;
using UnityEngine;

namespace FindDifferences.Infrastracture.DataSystem
{
    public class JsonSaveLoadService : ISaveLoadService
    {
        private const string FILE_NAME = "GameDataSave.json";
        private readonly string _mainPath;
       
        public JsonSaveLoadService()
        {
            _mainPath = Application.persistentDataPath;
        }

        public GameData Load()
        {
            string path = BuildPath();

            GameData loadedData = null;

            if (File.Exists(path))
            {            
                using (var fileStream = new StreamReader(path))
                {
                    var json = fileStream.ReadToEnd();

                    loadedData = JsonConvert.DeserializeObject<GameData>(json);
                }
            }
            else
            {
                loadedData = new GameData();
            }

            return loadedData;
        }

        public void Save(GameData data, Action onSaveCallback = null)
        {
            string path = BuildPath();

            string json = JsonConvert.SerializeObject(data);

            using (var fileStream = new StreamWriter(path))
            {
                 fileStream.Write(json);
            }

            onSaveCallback?.Invoke();
        }

        private string BuildPath()
        {
            return Path.Combine(_mainPath, FILE_NAME);
        }
    }
}
