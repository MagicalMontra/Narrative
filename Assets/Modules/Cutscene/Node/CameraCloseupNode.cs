using Cinemachine;
using UnityEngine;

namespace SETHD.Narrative
{
    public class CameraCloseupNode : MiddleNode
    {
        [Range(2, 10)]
        public float distance;
        [Range(0f, 0.77f)]
        public float angleThreshold;
        public Transform target;
        public CinemachineVirtualCameraBase camera;
        
        public override void Run()
        {
            base.Run();
            var center = new GameObject("rotator").transform;
            center.position = target.position;
            center.rotation = target.rotation;
            
            var cameraContainer = new GameObject("container").transform;
            var shiftY = Random.Range(-angleThreshold, angleThreshold);
            var shiftZ = Random.Range(-angleThreshold, angleThreshold * 0.5f);
            cameraContainer.SetParent(center);
            cameraContainer.position = MathExtensions.GetShiftFacingRadiant(center, distance, shiftY, shiftZ);
            SignalBusSingleton.Instance.Fire(new CameraPositionChangeRequestSignal(camera, cameraContainer));
            SignalBusSingleton.Instance.Fire(new CameraAimChangeRequestSignal(camera, target));
            MoveNext();
        }
    }
}