using FindDifferences.GamePlay;

namespace FindDiffereces.GamePlay.Levels
{
    public interface ILevelController : ILevelStateNotifier
    {
        void RestartLevel();
        void Init(LevelView level);
    }
}