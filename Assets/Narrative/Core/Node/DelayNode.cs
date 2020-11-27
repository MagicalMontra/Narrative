using System;
using System.Threading.Tasks;
using UnityEngine;
using XNode;

namespace SETHD.Narrative
{
    [Serializable]
    public class DelayNode : MiddleNode
    {
        public override void Run()
        {
            base.Run();
            MoveNext();
        }
    }
}