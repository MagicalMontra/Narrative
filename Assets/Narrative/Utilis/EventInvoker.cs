using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Utilis
{
    public class EventInvoker : MonoBehaviour
    {
        [Serializable]
        public enum InvokeCycle
        {
            Awake = 0,
            Start,
            None
        }
    
        [SerializeField] private UnityEvent _event;
        [SerializeField] private float _delay;
        [SerializeField] private InvokeCycle _cycle;

        private void Awake()
        {
            if (_cycle != InvokeCycle.Awake)
                return;

            Invoke();
        }
        private void Start()
        {
            if (_cycle != InvokeCycle.Start)
                return;

            Invoke();
        }
        public async void Invoke()
        {
            await Task.Delay(Mathf.CeilToInt(_delay * 1000));
            _event.Invoke();
        }
    }
}