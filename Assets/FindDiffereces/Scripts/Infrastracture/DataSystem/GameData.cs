using Newtonsoft.Json;
using System;

namespace FindDifferences.Infrastracture.DataSystem
{
    [Serializable]
    public class GameData : IReadOnlyGameData
    {
        [JsonProperty("level")]
        public int CurrentLevelIndex { get; set; }

        [JsonProperty("win")]
        public bool IsWin { get; set; }
    }
}