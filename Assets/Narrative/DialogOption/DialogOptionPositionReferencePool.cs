using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace SETHD.Narrative.DialogOption
{
    public class DialogOptionPositionReferencePool
    {
        [Inject] private DialogOptionPositionReference.Factory _positionReferenceFactory;
        
        private List<DialogOptionPositionReference> _positionReferences = new List<DialogOptionPositionReference>();

        public DialogOptionPositionReference GetPositionReference(Transform pool)
        {
            DialogOptionPositionReference positionReference = null;

            for (int i = 0; i < _positionReferences.Count; i++)
            {
                if (!_positionReferences[i].isActive)
                    positionReference = _positionReferences[i];
            }

            if (ReferenceEquals(positionReference, null))
            {
                positionReference = _positionReferenceFactory.Create();
                positionReference.transform.SetParent(pool.transform);
            }

            return positionReference;
        }

        public void DisableAll()
        {
            _positionReferences.ForEach(reference => reference.SetActive(false));
        }
    }
}