using FindDiffereces.GamePlay.FX;

namespace FindDiffereces.Factories
{
    public interface IVisualFxFactory
    {
        UIVisualFxBase CreateFx(FxType type);
        void HideAllCreated();
    }
}