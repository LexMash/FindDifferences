using UnityEngine;

namespace FindDifferences.GamePlay.FX
{
    public interface IVisualFxSpawnService
    {
        void HideAll();
        void ShowLostFx();
        void ShowTouchFxAt(Vector2 position);
        void ShowWinFx();
    }
}