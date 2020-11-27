using UnityEngine;
using Zenject;

namespace SETHD.Narrative.DialogOption
{
    [CreateAssetMenu(menuName = "Installers/Create DialogOptionInstaller", fileName = "DialogOptionInstaller", order = 0)]
    public class DialogOptionInstaller : ScriptableObjectInstaller<DialogOptionInstaller>
    {
        [SerializeField] private DialogOptionDatabase _database;
        [SerializeField] private DialogOptionButton _buttonPrefab;
        [SerializeField] private DialogOptionCanvas _buttonCanvasPrefab;
        [SerializeField] private DialogOptionPositionReference _positionReferencePrefab;
        public override void InstallBindings()
        {
            Container.Bind<DialogOptionController>().AsSingle();
            Container.Bind<DialogOptionDataHandler>().AsSingle();
            Container.Bind<DialogOptionDatabase>().FromInstance(_database).AsSingle();
            
            Container.BindInterfacesAndSelfTo<DialogOptionPresenter>().AsSingle();
            Container.Bind<DialogOptionButtonPool>().AsSingle();
            Container.Bind<DialogOptionPositionReferencePool>().AsSingle();
            
            Container.Bind<DialogOptionButton>().FromInstance(_buttonPrefab).AsSingle();
            Container.BindFactory<Transform, PlaceholderFactory<Transform>>().FromNewComponentOnNewGameObject();
            Container.BindFactory<DialogOptionCanvas, DialogOptionCanvas.Factory>().FromComponentInNewPrefab(_buttonCanvasPrefab);
            Container.BindFactory<Object, Transform, DialogOptionButton, DialogOptionButton.Factory>().FromFactory<DialogOptionButtonFactory>();
            Container.BindFactory<DialogOptionPositionReference, DialogOptionPositionReference.Factory>().FromComponentInNewPrefab(_positionReferencePrefab);
            
            Container.DeclareSignal<DialogOptionRequestSignal>();
            Container.DeclareSignal<DialogOptionResponseSignal>();
            Container.DeclareSignal<DialogOptionCancelRequest>();

            Container.BindSignal<DialogOptionRequestSignal>()
                .ToMethod<DialogOptionController>(c => c.OnDialogOptionRequest).FromResolve();
            
            Container.BindSignal<DialogOptionResponseSignal>()
                .ToMethod<DialogOptionPresenter>(p => p.OnDialogOptionResponse).FromResolve();
            
            Container.BindSignal<DialogOptionCancelRequest>()
                .ToMethod<DialogOptionPresenter>(p => p.OnDialogOptionCancelRequest).FromResolve();
        }
    }
}