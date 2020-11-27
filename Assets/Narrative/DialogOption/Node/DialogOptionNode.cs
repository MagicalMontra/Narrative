using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace SETHD.Narrative.DialogOption
{
    public class DialogOptionNode : DynamicMiddleNode
    {
        public string dialogId;
        public List<Transform> optionTransforms = new List<Transform>();

        public override void Run()
        {
            base.Run();
            var events = new List<UnityEvent>();
            var count = DynamicPorts.Count();
            for (int i = 0; i < count; i++)
            {
                var newEvent = new UnityEvent();
                var cacheI = i;
                newEvent.AddListener(() => this.GetNextNode($"output {cacheI}").Run());
                events.Add(newEvent);
            }
            SignalBusSingleton.Instance.Fire(new DialogOptionRequestSignal(dialogId, events, optionTransforms));
        }
    }
}