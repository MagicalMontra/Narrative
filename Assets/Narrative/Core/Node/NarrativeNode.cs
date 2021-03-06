﻿using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using XNode;

namespace SETHD.Narrative
{
    public abstract class NarrativeNode : Node
    {
        [HideInInspector]
        public bool isRunning;

        public float delay;

        public abstract void MoveNext();
        public abstract void Run();
    }

    public abstract class MiddleNode : NarrativeNode
    {
        [Input(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.Inherited)] 
        public NarrativeNode input;

        [Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.Inherited)]
        public NarrativeNode output;

        public override async void MoveNext()
        {
            await Task.Delay(Mathf.CeilToInt(1000 * delay));
            isRunning = false;
            this.GetNextNode("output").Run();
        }
        public override void Run()
        {
            isRunning = true;
        }
    }

    public abstract class DynamicMiddleNode : NarrativeNode
    {
        [Input(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.Inherited)] 
        public NarrativeNode input;

        [Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.Inherited, true)]
        public NarrativeNode output;
        
        public override async void MoveNext()
        {
            await Task.Delay(Mathf.CeilToInt(1000 * delay));
            isRunning = false;
            var count = DynamicPorts.Count();
            
            for (int i = 0; i < count; i++)
                this.GetNextNode($"output {i}").Run();

        }
        public override void Run()
        {
            isRunning = true;
        }
    }

    public abstract class StartNode : NarrativeNode
    {
        [Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.Inherited)]
        public NarrativeNode output;
        
        public override async void MoveNext()
        {
            await Task.Delay(Mathf.CeilToInt(1000 * delay));
            isRunning = false;
            this.GetNextNode("output").Run();
        }
        public override void Run()
        {
            isRunning = true;
        }
    }

    public abstract class EndNode : NarrativeNode
    {
        [Input(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.Inherited)] 
        public NarrativeNode input;
        
        public override async void MoveNext()
        {
            await Task.Delay(Mathf.CeilToInt(1000 * delay));
            isRunning = false;
            NarrativeGraph narrativeGraph = graph as NarrativeGraph;
            narrativeGraph.Finish();
        }
        public override void Run()
        {
            isRunning = true;
        }
    }
}