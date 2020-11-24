using Cinemachine;
using UnityEngine;

namespace SETHD.Narrative
{
    public class CameraAimChangeRequestSignal
    {
        public CinemachineVirtualCameraBase camera => _camera;
        public Transform[] transforms => _transforms;
        private CinemachineVirtualCameraBase _camera;
        private Transform[] _transforms;

        public CameraAimChangeRequestSignal(CinemachineVirtualCameraBase camera, params Transform[] transforms)
        {
            _camera = camera;
            _transforms = transforms;
        }
    }
    
    public class CameraPositionChangeRequestSignal
    {
        public CinemachineVirtualCameraBase camera => _camera;
        public Transform transform => _transform;
        private CinemachineVirtualCameraBase _camera;
        private Transform _transform;

        public CameraPositionChangeRequestSignal(CinemachineVirtualCameraBase camera, Transform transform)
        {
            _camera = camera;
            _transform = transform;
        }
    }
}