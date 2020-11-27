using UnityEngine;

namespace Gamespace.UI
{
    public class CanvasLookAtCamera : MonoBehaviour
    {
        [SerializeField] private bool _neededVisibility;
        [SerializeField] private Transform _uiElement;
        private Camera _camera;
        private bool _isVisible = true;

        private void OnEnable()
        {
            if (ReferenceEquals(_camera, null))
                _camera = Camera.main;
        }

        public void Update()
        {
            if (ReferenceEquals(_camera, null) || !_uiElement.gameObject.activeInHierarchy)
                return;

            if (_isVisible)
                _uiElement.position = _camera.WorldToScreenPoint(transform.position);
        }

        private void OnBecameVisible()
        {
            if (_neededVisibility)
                _isVisible = true;
        }

        private void OnBecameInvisible()
        {
            if (_neededVisibility)
                _isVisible = false;
        }
    }
}