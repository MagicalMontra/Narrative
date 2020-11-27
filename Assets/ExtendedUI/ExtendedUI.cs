using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Gamespace.UI
{
    public abstract class ExtendedUI : MonoBehaviour, IExtendedUI
    {
        public bool isInteractable = true;
        
        [SerializeField] protected UIAnimationFacade _clickBehaviour;
        [SerializeField] protected UIAnimationFacade _hoverBehaviour;
        [SerializeField] protected UIAnimationFacade _disableBehaviour;

        public UnityEvent onHover;
        
        protected bool _isActive = true;
        protected bool _isPointerDown;

        protected virtual void Awake()
        {

        }
        protected virtual void OnEnable()
        {
        }
        protected virtual void FixedUpdate()
        {
            if (_isActive != isInteractable)
            {
                _isActive = isInteractable;

                if (!_isActive)
                    _disableBehaviour?.Behaviour?.On();
                else
                    _disableBehaviour?.Behaviour?.Off();
            }
        }
        public virtual void OnPointerDown(PointerEventData eventData)
        {
            if (!_isActive || eventData.button != PointerEventData.InputButton.Left)
                return;
            
            if (Application.isMobilePlatform)
                _hoverBehaviour?.Behaviour?.On();
            
            _clickBehaviour?.Behaviour?.On();
            _isPointerDown = true;
        }
        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            if (!_isActive || Application.isMobilePlatform)
                return;

            Hover();
            _hoverBehaviour?.Behaviour?.On();
        }
        public virtual void OnPointerExit(PointerEventData eventData)
        {
            if (!_isActive || Application.isMobilePlatform)
                return;
            
            _hoverBehaviour?.Behaviour?.Off();
        }
        public virtual void OnPointerUp(PointerEventData eventData)
        {
            if (!_isActive || !_isPointerDown)
                return;
            
            if (Application.isMobilePlatform)
                _hoverBehaviour?.Behaviour?.Off();
            
            if (eventData.button != PointerEventData.InputButton.Left)
                return;

            _isPointerDown = false;
            _clickBehaviour?.Behaviour?.Off();
        }
        protected virtual void Hover()
        {
            onHover?.Invoke();
        }
    }
}