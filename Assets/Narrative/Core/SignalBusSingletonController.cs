using System;
using Zenject;
using Object = UnityEngine.Object;

namespace SETHD.Narrative
{
    public class SignalBusSingletonController : IInitializable, IDisposable
    {
        [Inject] private SignalBusSingleton.Factory _factory;

        private SignalBusSingleton _instance;
        
        public void Initialize()
        {
            _instance = _factory.Create();
        }
        public void Dispose()
        {
            Object.DestroyImmediate(_instance.gameObject);
        }
    }
}