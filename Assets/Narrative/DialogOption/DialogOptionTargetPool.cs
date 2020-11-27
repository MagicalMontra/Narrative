using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace SETHD.Narrative.DialogOption
{
    public class DialogOptionTargetPool
    {
        [Inject] private DialogOptionTargetContainer.Factory _prefabFactory;
        
        private List<DialogOptionTargetContainer> _pool = new List<DialogOptionTargetContainer>();
        private GameObject _poolParent = null;

        public DialogOptionTargetContainer GetObject()
        {
            DialogOptionTargetContainer container = null;
            
            if (ReferenceEquals(_poolParent, null))
                _poolParent = new GameObject("DialogOptionPool");

            for (int i = 0; i < _pool.Count; i++)
            {
                if (!_pool[i].isActive)
                    container = _pool[i];
            }

            if (ReferenceEquals(container, null))
            {
                container = _prefabFactory.Create();
                container.transform.SetParent(_poolParent.transform);
            }

            return container;
        }
    }
}