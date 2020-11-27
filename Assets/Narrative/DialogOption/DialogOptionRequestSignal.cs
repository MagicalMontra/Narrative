
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace SETHD.Narrative.DialogOption
{
    public class DialogOptionRequestSignal
    {
        public string id => _id;
        public List<UnityEvent> events => _events;
        public List<Transform> transforms => _transforms;
        
        private string _id;
        private List<UnityEvent> _events = new List<UnityEvent>();
        private List<Transform> _transforms = new List<Transform>();

        public DialogOptionRequestSignal(string id, List<UnityEvent> events, List<Transform> transforms)
        {
            _id = id;
            _events = events;
            _transforms = transforms;
        }
    }

    public class DialogOptionResponseSignal
    {
        public DialogOptionData data => _data;
        public List<UnityEvent> events => _events;
        public List<Transform> transforms => _transforms;
        
        private DialogOptionData _data;
        private List<UnityEvent> _events = new List<UnityEvent>();
        private List<Transform> _transforms = new List<Transform>();

        public DialogOptionResponseSignal(DialogOptionData data, List<UnityEvent> events, List<Transform> transforms)
        {
            _data = data;
            _events = events;
            _transforms = transforms;
        }
    }
}