using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Gamespace.UI
{
    public class ExtendedButton : ExtendedUI, IPointerClickHandler
    {
        public UnityEvent onClick;
        public bool preventClickSpamming;
        private bool _isClicking;

        protected override void Awake()
        {
            base.Awake();
            
            if (preventClickSpamming)
                _clickBehaviour.Function?.outComplete.AddListener(() => _isClicking = false);
        }

        public virtual void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
                return;

            Press();
        }
        protected virtual void Press()
        {
            if (!_isActive || _isClicking)
                return;

            if (preventClickSpamming)
                _isClicking = true;
            
            onClick?.Invoke();
        }
    }
}