using System.Collections;
using UnityEngine.Events;
using Zenject;

namespace SETHD.Narrative.DialogOption
{
    public class DialogOptionController
    {
        [Inject] private DialogOptionDataHandler _dataHandler;
        [Inject] private SignalBus _signalBus;

        public void OnDialogOptionRequest(DialogOptionRequestSignal signal)
        {
            var runtimeData = _dataHandler.Handle(signal.id);
            
            if (runtimeData != null)
                _signalBus.Fire(new DialogOptionResponseSignal(runtimeData, signal.events, signal.transforms, signal.exitEvent));
        }
    }
}

