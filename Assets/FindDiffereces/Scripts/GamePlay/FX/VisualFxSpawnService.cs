using FindDiffereces.Factories;
using FindDiffereces.GamePlay.FX;
using UnityEngine;

namespace FindDifferences.GamePlay.FX
{
    public class VisualFxSpawnService : IVisualFxSpawnService
    {
        private readonly IVisualFxFactory _factory;
        private readonly Vector2 _endGameParticlesTransform;

        public VisualFxSpawnService(IVisualFxFactory factory, Vector2 endGameParticlesTransform)
        {
            _factory = factory;
            _endGameParticlesTransform = endGameParticlesTransform;
        }

        public void ShowTouchFxAt(Vector2 position)
        {
            ShowFx(FxType.Touch, position);
        }

        public void ShowWinFx()
        {
            ShowFx(FxType.Win, _endGameParticlesTransform);
        }

        public void ShowLostFx()
        {
            ShowFx(FxType.Lost, _endGameParticlesTransform);
        }

        private void ShowFx(FxType type, Vector2 postion)
        {
            UIVisualFxBase fx = _factory.CreateFx(type);
            fx.SetPosition(postion);
            fx.Show();
        }

        public void HideAll()
        {
            _factory.HideAllCreated();
        }
    }
}
