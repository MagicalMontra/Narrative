using UnityEngine;

namespace SETHD.Narrative
{
    public class NarrativeGraph : XNode.NodeGraph
    {
        public bool isFinish => _isFinish;
        private bool _isFinish;

        public void Start()
        {
            if (!(nodes.Find(n => n.GetType() == typeof(InitiateNode)) is NarrativeNode initNode))
            {
                Debug.Log($"{GetType()} doesn't have start node");
                return;
            }
            
            initNode.Run();
        }
        public void Finish()
        {
            _isFinish = true;
        }
    }
}