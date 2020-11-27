using DG.Tweening;
using Gamespace.UI;
using UnityEngine;

namespace SETHD.Narrative.DialogOption
{
    public class RotateAnimation : UIAnimation
    {
        [SerializeField] private Vector3 _rotation;
        [SerializeField] private Transform _target;

        private bool _hasOriginal;
        private Vector3 _original;
        
        public override void In(Sequence sequence)
        {
            if (!_hasOriginal)
            {
                _hasOriginal = true;
                _original = _target.rotation.eulerAngles;
            }
            
            sequence.Append(_target.DORotate(_rotation, _duration).SetEase(_ease));
        }
        public override void Out(Sequence sequence)
        {
            sequence.Append(_target.DORotate(_original, _duration).SetEase(_ease));
        }
        public override void Reset()
        {
            _target.rotation = Quaternion.Euler(_original);
        }
    }
}