using System;
using System.Threading.Tasks;
using UnityEngine;

namespace SETHD.Narrative
{
    [Serializable]
    public class InitiateNode : StartNode
    {
        public override void Run()
        {
            base.Run();
            MoveNext();
        }
    }
}