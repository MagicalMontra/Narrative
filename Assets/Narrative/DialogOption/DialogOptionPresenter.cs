using Zenject;

namespace SETHD.Narrative.DialogOption
{
    public class DialogOptionPresenter
    {
        [Inject] private DialogOptionTargetPool _pool;
        
        public void OnDialogOptionResponse(DialogOptionResponseSignal signal)
        {
            var data = signal.data;

            for (int i = 0; i < data.count; i++)
            {
                var container = _pool.GetObject();
                container.button.onClick.RemoveAllListeners();
                container.button.onClick.AddListener(signal.events[i].Invoke);
                container.button.onClick.AddListener(() => container.SetActive(false));
                container.transform.position = signal.transforms[i].position;
                container.target = signal.transforms[i];
                container.SetActive(true);
            }
        }
    }
}