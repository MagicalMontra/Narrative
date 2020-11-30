using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace SETHD.Narrative.DialogOption
{
    public class DialogOptionNode : DynamicMiddleNode
    {
        public string dialogId;
        public List<DialogNodeOption> options = new List<DialogNodeOption>();

        public override void Run()
        {
            base.Run();
            var events = new List<UnityEvent>();
            var optionTransforms = new List<Transform>();
            var count = DynamicPorts.Count();
            for (int i = 0; i < count; i++)
            {
                var newEvent = new UnityEvent();
                var cacheI = i;
                newEvent.AddListener(() => this.GetNextNode($"output {cacheI}").Run());
                
                if (i < options.Count && options[i].endDialog)
                    newEvent.AddListener(() => SignalBusSingleton.Instance.Fire(new DialogOptionCancelRequest()));
                
                events.Add(newEvent);
            }

            for (int i = 0; i < options.Count; i++)
                optionTransforms.Add(options[i].transform);
            
            SignalBusSingleton.Instance.Fire(new DialogOptionRequestSignal(dialogId, events, optionTransforms));
        }
    }

    [Serializable]
    public class DialogNodeOption
    {
        public bool endDialog;
        public Transform transform;
    }
}