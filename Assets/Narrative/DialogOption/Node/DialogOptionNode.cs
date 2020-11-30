using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace SETHD.Narrative.DialogOption
{
    public class DialogOptionNode : DynamicMiddleNode
    {
        public int count;
        public bool haveExit;
        public string dialogId;
        public List<DialogNodeOption> options = new List<DialogNodeOption>();

        public override async void Run()
        {
            base.Run();
            await Task.Delay(Mathf.CeilToInt(1000 * delay));
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

            if (haveExit)
            {
                var exitEvent = new UnityEvent();
                exitEvent.AddListener(() => this.GetNextNode($"exit").Run());
                SignalBusSingleton.Instance.Fire(new DialogOptionRequestSignal(dialogId, events, optionTransforms,
                    exitEvent));
            }
            else
                SignalBusSingleton.Instance.Fire(new DialogOptionRequestSignal(dialogId, events, optionTransforms));

            isRunning = false;
        }
    }

    [Serializable]
    public class DialogNodeOption
    {
        public bool endDialog;
        public Transform transform;
    }
}