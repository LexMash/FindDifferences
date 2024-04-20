using FindDifferences.GamePlay;

namespace FindDiffereces.GamePlay.Levels
{
    public interface ILevelController : ILevelNotifier
    {
        void RestartLevel();
        void SetLevel(LevelView level);
    }
}