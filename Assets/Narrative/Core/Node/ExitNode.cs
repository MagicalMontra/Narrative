using System;

namespace SETHD.Narrative
{
    [Serializable]
    public class ExitNode : EndNode
    {
        public override void Run()
        {
            MoveNext();
        }
    }
}