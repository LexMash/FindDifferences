

using UnityEngine;

namespace FindDiffereces.Data
{
    [CreateAssetMenu (fileName = "New GameConfig", menuName = "FindDifferences/GameConfig")]
    public class GameConfig : ScriptableObject
    {
        [field: SerializeField] public float TimeForFindInSeconds { get; private set; } = 120f;
    }
}

