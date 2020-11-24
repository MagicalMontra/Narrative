using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using Zenject;

namespace SETHD.Narrative
{
    public class OrientCameraSet : MonoBehaviour, ICameraSet
    {
        [Inject] private SignalBus _signalBus;
        
        [SerializeField] private List<Transform> _setObjects = new List<Transform>();
        [SerializeField] private Vector3 _speed;
        private Vector3 _centerPoint;
        private Transform _center;
        private bool _isRotating;

        private void Awake()
        {
            _centerPoint = VectorExtensions.FindCenter(_setObjects.ToArray());

            _center = new GameObject().transform;
            _center.SetParent(transform);
            _center.position = _centerPoint;
        }
        public void InitializeSet()
        {

            _isRotating = true;
        }
        public void DisposeSet()
        {
            _isRotating = false;
        }
        private void Update()
        {
            if (!_isRotating)
                return;
            
            
            _center.Rotate(_speed.x * Time.deltaTime, _speed.y * Time.deltaTime, _speed.z * Time.deltaTime);
        }
    }
}