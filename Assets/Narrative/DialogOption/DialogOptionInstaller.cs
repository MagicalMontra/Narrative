using UnityEngine;
using Zenject;

namespace SETHD.Narrative.DialogOption
{
    [CreateAssetMenu(menuName = "Installers/Create DialogOptionInstaller", fileName = "DialogOptionInstaller", order = 0)]
    public class DialogOptionInstaller : ScriptableObjectInstaller<DialogOptionInstaller>
    {
        [SerializeField] private DialogOptionDatabase _database;
        [SerializeField] private DialogOptionTargetContainer _prefab;
        public override void InstallBindings()
        {
            Container.Bind<DialogOptionController>().AsSingle();
            Container.Bind<DialogOptionDataHandler>().AsSingle();
            Container.Bind<DialogOptionDatabase>().FromInstance(_database).AsSingle();
            
            Container.Bind<DialogOptionPresenter>().AsSingle();
            Container.Bind<DialogOptionTargetPool>().AsSingle();
            Container.BindFactory<DialogOptionTargetContainer, DialogOptionTargetContainer.Factory>()
                .FromComponentInNewPrefab(_prefab);

            Container.DeclareSignal<DialogOptionRequestSignal>();
            Container.DeclareSignal<DialogOptionResponseSignal>();

            Container.BindSignal<DialogOptionRequestSignal>()
                .ToMethod<DialogOptionController>(c => c.OnDialogOptionRequest).FromResolve();
            
            Container.BindSignal<DialogOptionResponseSignal>()
                .ToMethod<DialogOptionPresenter>(p => p.OnDialogOptionResponse).FromResolve();
        }
    }
}