using DG.Tweening;
using UnityEngine;
using Zenject;

namespace SETHD.Narrative
{
    public class CameraCutHandler : IInitializable
    {
        [Inject] private CameraCutSettings.Factory _settingsFactory;
        
        private CameraCutSettings _settings;
        private Tween _tween;
        
        public void Initialize()
        {
            _settings = _settingsFactory.Create();
        }
        public void Handle(Ease ease, float duration, float targetFade, string colorString)
        {
            var color = Color.black;
            ColorUtility.TryParseHtmlString(colorString, out color);
            _settings.cutFade.color = color;
            
            _tween?.Kill();
            _tween = _settings.fader.DOFade(targetFade, duration).SetEase(ease);
        }
    }
}