using Gamespace.UI;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace SETHD.Narrative.DialogOption
{
    public class DialogOptionButton : MonoBehaviour
    {
        public bool isActive => _isActive;
        public ExtendedButton button;

        [SerializeField] private UIAnimationFacade _indicatorAnimation;

        
        private bool _isActive;

        public void SetActive(bool enabled)
        {
            gameObject.SetActive(enabled);
            
            if (enabled)
                _indicatorAnimation.Behaviour?.On();
            else
                _indicatorAnimation.Behaviour?.Off();

            _isActive = enabled;
        }
        
        public class Factory : PlaceholderFactory<Object, Transform, DialogOptionButton> { }
    }
}