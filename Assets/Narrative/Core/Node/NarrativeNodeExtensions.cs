
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace SETHD.Narrative
{
    public static class NarrativeNodeExtensions
    {
        public static List<NarrativeNode> GetNextNode(this NarrativeNode currentNode, string fieldName)
        {
            NodePort exitPort = currentNode.GetOutputPort(fieldName);

            if (!exitPort.IsConnected) {
                Debug.LogWarning("Node isn't connected");
                return null;
            }

            List<NarrativeNode> nodes = new List<NarrativeNode>();
            var connections = exitPort.GetConnections();

            for (int i = 0; i < connections.Count; i++)
                nodes.Add(connections[i].node as NarrativeNode);
            
            return nodes;
        }

        public static void Run(this List<NarrativeNode> nodes)
        {
            if (nodes.Count <= 0)
            {
                Debug.LogWarning("Node isn't connected");
                return;
            }

            for (int i = 0; i < nodes.Count; i++)
            {
                if (!nodes[i].isRunning)
                    nodes[i].Run();
            }
        }
    }
}