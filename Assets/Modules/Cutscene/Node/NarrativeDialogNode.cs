using System;
using System.Collections.Generic;
using UnityEngine.Events;
using XNode;

namespace SETHD.Narrative
{
    [Serializable]
    public class NarrativeDialogNode : MiddleNode
    {
        [Output(dynamicPortList = true)]
        public List<UnityEvent> outputs = new List<UnityEvent>();
    }
}