using System.Collections.Generic;
using UnityEngine;

namespace SETHD.Narrative
{
    public class CameraAimPointPool
    {
        private List<CameraAimPoint> _aimPoints = new List<CameraAimPoint>();

        public CameraAimPoint GetAimPoint()
        {
            CameraAimPoint aimPoint = null;
            
            for (int i = 0; i < _aimPoints.Count; i++)
            {
                if (!_aimPoints[i].active)
                {
                    aimPoint = _aimPoints[i];
                    break;
                }
            }

            if (ReferenceEquals(aimPoint, null))
            {
                aimPoint = new GameObject("aim point").AddComponent<CameraAimPoint>();
                _aimPoints.Add(aimPoint);
            }

            return aimPoint;
        }

        public void DisableAll()
        {
            _aimPoints.ForEach(reference => reference.SetDisable());
        }
    }
}