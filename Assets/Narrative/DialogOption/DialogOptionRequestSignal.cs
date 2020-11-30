
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
        public UnityEvent exitEvent => _exitEvent;
        
        private string _id;
        private List<UnityEvent> _events = new List<UnityEvent>();
        private List<Transform> _transforms = new List<Transform>();
        private UnityEvent _exitEvent;

        public DialogOptionRequestSignal(string id, List<UnityEvent> events, List<Transform> transforms, UnityEvent exitEvent = null)
        {
            _id = id;
            _events = events;
            _transforms = transforms;
            _exitEvent = exitEvent;
        }
    }

    public class DialogOptionResponseSignal
    {
        public DialogOptionData data => _data;
        public List<UnityEvent> events => _events;
        public List<Transform> transforms => _transforms;
        public UnityEvent exitEvent => _exitEvent;
        
        private DialogOptionData _data;
        private List<UnityEvent> _events = new List<UnityEvent>();
        private List<Transform> _transforms = new List<Transform>();
        private UnityEvent _exitEvent;

        public DialogOptionResponseSignal(DialogOptionData data, List<UnityEvent> events, List<Transform> transforms, UnityEvent exitEvent = null)
        {
            _data = data;
            _events = events;
            _transforms = transforms;
            _exitEvent = exitEvent;
        }
    }
}