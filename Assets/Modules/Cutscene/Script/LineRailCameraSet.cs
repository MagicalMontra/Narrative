
using System;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace SETHD.Narrative
{
    public class LineRailCameraSet : MonoBehaviour, ICameraSet
    {
        [SerializeField] private CinemachineVirtualCameraBase _camera;
        [SerializeField] private Transform _startObject;
        [SerializeField] private Transform _endObject;
        [SerializeField] private float _offset;
        [SerializeField] private float _duration;
        [SerializeField] private bool _reverse;
        [SerializeField] private bool _moveCamera;

        private Vector3 _startPoint;
        private Vector3 _endPoint;

        private Transform _aimPoint;

        private Tween _tween;

        private void Awake()
        {
            _startPoint = (_startObject.position + -(_endObject.position - _startObject.position).normalized * _offset);
            _endPoint = (_endObject.position + -(_startObject.position - _endObject.position).normalized * _offset);
            _aimPoint = new GameObject($"{gameObject.name} aim point").transform;
            _aimPoint.SetParent(transform);
            
            if (_reverse)
                _aimPoint.transform.position = _endPoint;
            else
                _aimPoint.transform.position = _startPoint;
            
            if (_moveCamera)
                _camera.transform.SetParent(_aimPoint);

            _camera.LookAt = _aimPoint;
        }
        public void InitializeSet()
        {
            if (_reverse)
                _tween = _aimPoint.transform.DOMove(_startPoint, _duration);
            else
                _tween = _aimPoint.transform.DOMove(_endPoint, _duration);
        }
        public void DisposeSet()
        {
            _tween.Kill();
        }
    }
}