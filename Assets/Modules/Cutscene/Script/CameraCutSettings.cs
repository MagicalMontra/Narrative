using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SETHD.Narrative
{
    public class CameraCutSettings : MonoBehaviour
    {
        public CanvasGroup fader;
        public Image cutFade;
        
        public class Factory : PlaceholderFactory<CameraCutSettings>{}
    }
}