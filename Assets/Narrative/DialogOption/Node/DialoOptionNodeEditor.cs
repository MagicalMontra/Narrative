using System.Linq;
using Cinemachine.Editor;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Events;
using XNode;
using XNodeEditor;

namespace SETHD.Narrative.DialogOption
{
    [CustomNodeEditor(typeof(DialogOptionNode))]
    public class DialoOptionNodeEditor : NodeEditor
    {
        private DialogOptionNode _node;
        private bool _isInitialize;
        public override void OnBodyGUI()
        {
            Initialize();
            
            // Update serialized object's representation
            serializedObject.Update();

            NodeEditorGUILayout.DynamicPortList("output", typeof(NarrativeNode), serializedObject, NodePort.IO.Output, Node.ConnectionType.Override, Node.TypeConstraint.Strict, OnCreateReorderableList);
            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("options"));


            // Apply property modifications
            serializedObject.ApplyModifiedProperties();
        }
        void OnCreateReorderableList(ReorderableList list)
        {
            list.drawElementCallback = (rect, index, active, focused) =>
            {
                if (index > 0)
                    rect.y += 20;
                
                _node.options[index].endDialog = EditorGUI.ToggleLeft(rect, "End Dialog", _node.options[index].endDialog);
                rect.y += 20;
                _node.options[index].transform = (Transform)EditorGUI.ObjectField(rect, _node.options[index].transform, typeof(Transform), true);
            };
            
            serializedObject.ApplyModifiedProperties();
            EditorUtility.SetDirty(_node);
        }
        private void Initialize()
        {
            if (_isInitialize)
                return;
            
            if (_node == null) _node = target as DialogOptionNode;

            _isInitialize = true;
        }
    }
}