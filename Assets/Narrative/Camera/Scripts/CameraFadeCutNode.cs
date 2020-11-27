using System;
using DG.Tweening;
using UnityEngine;

namespace SETHD.Narrative
{
    [Serializable]
    public class CameraFadeCutNode : MiddleNode
    {
        public float fadeAmount;
        public float duration;
        public Color32 color;
        public Ease ease;
        
        public override void Run()
        {
            base.Run();
            SignalBusSingleton.Instance.Fire(new CameraFadeCutRequestSignal(ease, duration, fadeAmount, ColorUtility.ToHtmlStringRGBA(color)));
            MoveNext();
        }
    }
}