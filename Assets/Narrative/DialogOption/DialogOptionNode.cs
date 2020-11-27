using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SETHD.Narrative.DialogOption
{
    public class DialogOptionNode : MiddleNode
    {
        public string dialogId;
        public List<UnityEvent> optionEvents = new List<UnityEvent>();
        public List<Transform> optionTransforms = new List<Transform>();

        public override void Run()
        {
            base.Run();
            SignalBusSingleton.Instance.Fire(new DialogOptionRequestSignal(dialogId, optionEvents, optionTransforms));
            MoveNext();
        }
    }
}