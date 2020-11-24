using Cinemachine;
using UnityEngine;

namespace SETHD.Narrative
{
    public class CameraPositionHandler
    {
        public void Handle(CinemachineVirtualCameraBase camera, Transform to)
        {
            camera.transform.SetParent(to);
        }
    }
}