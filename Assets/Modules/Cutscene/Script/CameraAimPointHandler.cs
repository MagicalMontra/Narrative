using Cinemachine;
using UnityEngine;
using Zenject;

namespace SETHD.Narrative
{
    public class CameraAimPointHandler
    {
        [Inject] private CameraAimPointPool _pool;
        
        public void Handle(CinemachineVirtualCameraBase camera, params Transform[] transforms)
        {
            if (transforms.Length <= 1)
                camera.LookAt = transforms[0];
            else
            {
                var centerPoint = VectorExtensions.FindCenter(transforms);
                var aimPoint = _pool.GetAimPoint().SetAimPoint();
                aimPoint.position = centerPoint;
                camera.LookAt = aimPoint;
            }
            
        }
    }
}