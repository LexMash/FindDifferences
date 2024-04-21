using FindDiffereces.GamePlay.FX;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace FindDiffereces.Factories
{
    public sealed class VisualFxFactory : IDisposable, IVisualFxFactory, IInitializable
    {
        private readonly RectTransform _parent;

        private readonly Dictionary<FxType, List<UIVisualFxBase>> _released = new();
        private readonly List<UIVisualFxBase> _active = new();
        private readonly List<AsyncOperationHandle> _handles = new();

        public void Initialize()
        {
            //prefabload
        }

        public UIVisualFxBase CreateFx(FxType type)
        {
            UIVisualFxBase fx = null;

            if (_released.TryGetValue(type, out List<UIVisualFxBase> list))
            {
                fx = list[list.Count - 1];
                list.Remove(fx);

                _active.Add(fx);
            }
            else
            {
                fx = UnityEngine.Object.Instantiate(null, _parent).GetComponent<UIVisualFxBase>();
                _active.Add(fx);
            }

            fx.Shown += FxShown;

            return fx;
        }

        public void HideAllCreated()
        {
            foreach (var fx in _active)
                fx.Hide();
        }

        public void Dispose()
        {
            foreach (var kvp in _released)
            {
                kvp.Value.Clear();
            }

            _released.Clear();
            _active.Clear();

            foreach(var handle in _handles)
            {
                Addressables.Release(handle);
            }

            _handles.Clear();
        }

        private void FxShown(UIVisualFxBase fx)
        {
            fx.Shown -= FxShown;
            _active.Remove(fx);

            AddToReleased(fx);
        }

        private void AddToReleased(UIVisualFxBase fx)
        {
            if (_released.TryGetValue(fx.Type, out List<UIVisualFxBase> list))
            {
                list.Add(fx);
            }
            else
            {
                var newList = new List<UIVisualFxBase>();

                _released[fx.Type] = newList;

                newList.Add(fx);
            }
        }
    }
}
