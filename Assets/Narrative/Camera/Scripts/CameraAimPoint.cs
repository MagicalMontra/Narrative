using UnityEngine;

namespace SETHD.Narrative
{
    public class CameraAimPoint : MonoBehaviour
    {
        public bool active => _active;
        private bool _active;

        public Transform SetAimPoint()
        {
            _active = true;
            return transform;
        }
    }
}