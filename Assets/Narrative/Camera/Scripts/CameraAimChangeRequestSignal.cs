using Cinemachine;
using DG.Tweening;
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

    public class CameraFadeCutRequestSignal
    {
        public Ease ease => _ease;
        public float duration => _duration;
        public float fadeAmount => _fadeAmount;
        public string color => _color;
        
        private Ease _ease;
        private float _duration;
        private float _fadeAmount;
        private string _color;

        public CameraFadeCutRequestSignal( Ease ease, float duration, float fadeAmount, string color = "000000FF")
        {
            _ease = ease;
            _duration = duration;
            _fadeAmount = fadeAmount;
            _color = $"#{color}";
        }
    }
}