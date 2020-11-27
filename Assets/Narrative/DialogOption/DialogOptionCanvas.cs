using UnityEngine;
using Zenject;

namespace SETHD.Narrative.DialogOption
{
    public class DialogOptionCanvas : MonoBehaviour
    {
        public class Factory : PlaceholderFactory<DialogOptionCanvas>{}
    }
}