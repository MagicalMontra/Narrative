
using UnityEngine;
using Zenject;

namespace SETHD.Narrative
{
    [CreateAssetMenu(menuName = "Installers/Create Camera Installer", fileName = "CameraInstaller", order = 0)]
    public class CameraInstaller : ScriptableObjectInstaller<CameraInstaller>
    {
        [SerializeField] private CameraCutSettings _cameraCutPrefab;
        public override void InstallBindings()
        {
            Container.Bind<CameraController>().AsSingle();
            Container.Bind<CameraAimPointHandler>().AsSingle();
            Container.Bind<CameraPositionHandler>().AsSingle();
            Container.Bind<CameraAimPointPool>().AsSingle();
            Container.Bind<CameraPositionPointPool>().AsSingle();
            Container.BindInterfacesAndSelfTo<CameraCutHandler>().AsSingle();
            
            Container.BindFactory<CameraCutSettings, CameraCutSettings.Factory>()
                .FromComponentInNewPrefab(_cameraCutPrefab);

            Container.DeclareSignal<CameraAimChangeRequestSignal>();
            Container.DeclareSignal<CameraPositionChangeRequestSignal>();
            Container.DeclareSignal<CameraFadeCutRequestSignal>();

            Container.BindSignal<CameraAimChangeRequestSignal>()
                .ToMethod<CameraController>(c => c.OnCameraAimChangeRequest).FromResolve();
            Container.BindSignal<CameraPositionChangeRequestSignal>()
                .ToMethod<CameraController>(c => c.OnCameraPositionChangeRequest).FromResolve();
            Container.BindSignal<CameraFadeCutRequestSignal>()
                .ToMethod<CameraController>(c => c.OnCameraCutRequest).FromResolve();
        }
    }
}