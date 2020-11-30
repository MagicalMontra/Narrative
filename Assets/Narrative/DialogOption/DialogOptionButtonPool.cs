using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace SETHD.Narrative.DialogOption
{
    public class DialogOptionButtonPool
    {
        [Inject] private DialogOptionButton.Factory _buttonFactory;
        [Inject] private DialogOptionButton _buttonPrefab;
        
        private List<DialogOptionButton> _buttonPool = new List<DialogOptionButton>();

        public DialogOptionButton GetButton(Transform canvas)
        {
            DialogOptionButton button = null;
            
            for (int i = 0; i < _buttonPool.Count; i++)
            {
                if (!_buttonPool[i].isActive)
                    button = _buttonPool[i];
            }

            if (ReferenceEquals(button, null))
            {
                button = _buttonFactory.Create(_buttonPrefab, canvas);
                _buttonPool.Add(button);
            }

            return button;
        }

        public void DisableAll()
        {
            _buttonPool.ForEach(button => button.SetActive(false));
        }
    }
}