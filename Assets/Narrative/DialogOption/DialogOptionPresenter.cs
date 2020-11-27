using UnityEngine;
using Zenject;

namespace SETHD.Narrative.DialogOption
{
    public class DialogOptionPresenter : IInitializable
    {
        [Inject] private DialogOptionButtonPool _buttonPool;
        [Inject] private DialogOptionCanvas.Factory _canvasFactory;
        [Inject] private DialogOptionPositionReferencePool _positionReferencePool;
        [Inject] private PlaceholderFactory<Transform> _poolTFactory;
        
        private Transform _canvas;
        private Transform _refPoolTransform;
        
        public void Initialize()
        {
            if (ReferenceEquals(_canvas, null))
                _canvas = _canvasFactory.Create().transform;

            if (ReferenceEquals(_refPoolTransform, null))
            {
                _refPoolTransform = _poolTFactory.Create();
                _refPoolTransform.gameObject.name = "DialogOptionPosRef";
            }
        }
        public void OnDialogOptionResponse(DialogOptionResponseSignal signal)
        {
            _canvas.gameObject.SetActive(true);
            
            var data = signal.data;

            for (int i = 0; i < data.count; i++)
            {
                var optionUI = _buttonPool.GetButton(_canvas);
                optionUI.button.onClick.RemoveAllListeners();
                optionUI.button.onClick.AddListener(signal.events[i].Invoke);
                optionUI.button.onClick.AddListener(() => optionUI.SetActive(false));
                optionUI.SetActive(true);
                
                var posRef = _positionReferencePool.GetPositionReference(_refPoolTransform);
                posRef.transform.position = signal.transforms[i].position;
                posRef.SetActive(true);
                posRef.SetTarget(optionUI.transform);
            }
        }
        public void OnDialogOptionCancelRequest(DialogOptionCancelRequest signal)
        {
            _buttonPool.DisableAll();
            _positionReferencePool.DisableAll();
            _canvas.gameObject.SetActive(false);
        }
    }
}