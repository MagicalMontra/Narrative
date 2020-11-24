using Zenject;

namespace SETHD.Narrative
{
    public class CameraController
    {
        [Inject] private CameraAimPointHandler _aimPointHandler;
        [Inject] private CameraPositionHandler _positionHandler;
        [Inject] private SignalBus _signalBus;

        public void OnCameraAimChangeRequest(CameraAimChangeRequestSignal signal)
        {
            _aimPointHandler.Handle(signal.camera, signal.transforms);
        }

        public void OnCameraPositionChangeRequest(CameraPositionChangeRequestSignal signal)
        {
            _positionHandler.Handle(signal.camera, signal.transform);
        }
    }
}