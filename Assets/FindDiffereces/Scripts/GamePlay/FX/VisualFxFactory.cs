using FindDifferences.GamePlay.FX;
using FindDifferences.UI;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace FindDifferences.Factories
{
    public sealed class VisualFxFactory : IDisposable, IVisualFxFactory
    {
        private readonly UIFxRoot _parent;

        private readonly Dictionary<FxType, List<UIVisualFxBase>> _released = new();
        private readonly List<UIVisualFxBase> _active = new();
        private readonly List<AsyncOperationHandle> _handles = new();
        private UIVisualFxBase _fx; //fortest

        public VisualFxFactory(UIFxRoot parent)
        {
            _parent = parent;
        }

        public async void Initialize()
        {
            var handle = Addressables.LoadAssetAsync<GameObject>("TouchFx");
            await handle.Task;
            var go = handle.Result;
            _fx = go.GetComponent<UIVisualFxBase>();
        }

        public UIVisualFxBase CreateFx(FxType type)
        {
            UIVisualFxBase fx = null;

            if (_released.TryGetValue(type, out List<UIVisualFxBase> list))
            {
                fx = list[list.Count - 1];
                list.Remove(fx);

                if(list.Count == 0)
                    _released.Remove(type);
            }
            else
            {
                fx = UnityEngine.Object.Instantiate(_fx, _parent.Transform).GetComponent<UIVisualFxBase>();             
            }

            _active.Add(fx);
            fx.Shown += FxShown;

            return fx;
        }

        public void HideAllCreated()
        {
            for (int i = 0; i < _active.Count; i++)
            {
                UIVisualFxBase fx = _active[i];
                fx.Hide();
            }
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
