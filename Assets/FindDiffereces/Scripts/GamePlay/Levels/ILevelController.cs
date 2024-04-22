using FindDifferences.GamePlay;

namespace FindDifferences.GamePlay.Levels
{
    public interface ILevelController
    {
        void RestartLevel();
        void Init(LevelView level);
    }
}