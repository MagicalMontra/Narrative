using System.Collections;
using System.Collections.Generic;
using SETHD.Narrative;
using UnityEngine;
using Zenject;

[CreateAssetMenu(menuName = "Installers/Create ProjectInstaller", fileName = "ProjectInstaller", order = 0)]
public class ProjectInstaller : ScriptableObjectInstaller<ProjectInstaller>
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<SignalBusSingletonController>().AsSingle();
        Container.BindFactory<SignalBusSingleton, SignalBusSingleton.Factory>().FromNewComponentOnNewGameObject();
        SignalBusInstaller.Install(Container);
    }
}
