using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SETHD.Narrative
{
    public class CameraPositionContainer : MonoBehaviour
    {
        public virtual bool active => transform.childCount > 0;    
        public virtual void SetCamera(Transform cameraTransform)
        {
            cameraTransform.SetParent(transform);
            cameraTransform.position = Vector3.zero;
        }
    }

    public class CameraCloseupContainer : CameraPositionContainer
    {
        public override bool active => _container.childCount > 0;
        private float _angleThreshold = 45f;
        private Transform _center;
        private Transform _container;
        public override void SetCamera(Transform cameraTransform)
        {

        }
    }
}