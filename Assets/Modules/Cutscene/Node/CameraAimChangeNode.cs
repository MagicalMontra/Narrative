using System;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using XNode;

namespace SETHD.Narrative
{
    [Serializable]
    public class CameraAimChangeNode : MiddleNode
    {
        public CinemachineVirtualCameraBase camera;
        public List<Transform> objectsToAim = new List<Transform>();
        
        public override void Run()
        {
            base.Run();
            SignalBusSingleton.Instance.Fire(new CameraAimChangeRequestSignal(camera, objectsToAim.ToArray()));
            MoveNext();
        }
    }
}