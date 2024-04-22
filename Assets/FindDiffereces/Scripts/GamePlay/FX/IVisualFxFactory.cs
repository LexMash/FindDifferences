using FindDifferences.GamePlay.FX;

namespace FindDifferences.Factories
{
    public interface IVisualFxFactory
    {
        void Initialize();
        UIVisualFxBase CreateFx(FxType type);
        void HideAllCreated();
    }
}