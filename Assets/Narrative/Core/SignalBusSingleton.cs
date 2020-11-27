using UnityEngine;
using Zenject;

namespace SETHD.Narrative
{
    public class SignalBusSingleton : Singleton<SignalBusSingleton>
    {
        [Inject] private SignalBus _signalBus;

        public void Fire(object signal)
        {
            _signalBus.Fire(signal);
        }
        
        public class Factory : PlaceholderFactory<SignalBusSingleton>{}
    }
}