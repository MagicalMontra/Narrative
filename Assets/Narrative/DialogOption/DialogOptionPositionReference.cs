
using Gamespace.UI;
using UnityEngine;
using Zenject;

namespace SETHD.Narrative.DialogOption
{
    public class DialogOptionPositionReference : MonoBehaviour
    {
        public bool isActive => cameraTrack.gameObject.activeInHierarchy;
        public CanvasLookAtCamera cameraTrack;

        public void SetActive(bool enabled)
        {
            cameraTrack.gameObject.SetActive(enabled);
        }
        public void SetTarget(Transform transform)
        {
            cameraTrack.target = transform;
        }
        public class Factory : PlaceholderFactory<DialogOptionPositionReference>{}
    }
}