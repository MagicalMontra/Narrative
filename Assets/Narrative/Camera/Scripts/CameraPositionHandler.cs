using Cinemachine;
using UnityEngine;
using Zenject;

namespace SETHD.Narrative
{
    public class CameraPositionHandler
    {
        [Inject] private CameraPositionPointPool _pool;
        public void Handle(CinemachineVirtualCameraBase camera, Transform to)
        {
            var container = _pool.GetContainer();
            container.transform.position = to.position;
            container.SetCamera(camera.transform);
            container.transform.SetParent(to);
            camera.transform.position = container.transform.position;
        }
    }
}