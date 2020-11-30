using Gamespace.UI;
using UnityEngine;
using Zenject;

namespace SETHD.Narrative.DialogOption
{
    public class DialogOptionCanvas : MonoBehaviour
    {
        public ExtendedButton leaveButton;
        public class Factory : PlaceholderFactory<DialogOptionCanvas>{}
    }
}