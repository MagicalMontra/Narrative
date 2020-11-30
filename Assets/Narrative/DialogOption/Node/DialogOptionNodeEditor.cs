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
    public class DialogOptionNodeEditor : NodeEditor
    {
        private DialogOptionNode _node; 
        private bool _isInitialize;
        public override void OnBodyGUI()
        {
            Initialize();
            
            // Update serialized object's representation
            serializedObject.Update();

            NodeEditorGUILayout.PortField(new GUIContent(""), _node.GetPort($"input"));
 
            if (GUILayout.Button("Search for dialog"))
            {
                DialogOptionSearchWindow.Open(_node);
            }
            
            EditorGUILayout.BeginVertical("Button");
            GUILayout.Label($"Dialog ID: {_node.dialogId}", EditorStyles.largeLabel);
            EditorGUILayout.EndVertical();

            if (_node.DynamicPorts.Count() < _node.count)
            {
                _node.options.Clear();
                _node.DynamicPorts.ToList().Clear();
                for (int i = 0; i < _node.count; i++)
                {
                    _node.AddDynamicOutput(typeof(NarrativeNode), Node.ConnectionType.Multiple, Node.TypeConstraint.Inherited, $"output {i}");
                    _node.options.Add(new DialogNodeOption());
                }
                
                if (_node.haveExit)
                    _node.AddDynamicOutput(typeof(NarrativeNode), Node.ConnectionType.Multiple, Node.TypeConstraint.Inherited, $"exit");
            }
            
            EditorGUILayout.BeginVertical("Button");
            GUILayout.Label("Options", EditorStyles.largeLabel);
            EditorGUILayout.EndVertical();
            
            for (int i = 0; i < _node.options.Count; i++)
            {
                EditorGUILayout.BeginVertical("Button");
                GUILayout.Label($"Options# {i + 1}");
                _node.options[i].endDialog = EditorGUILayout.ToggleLeft("End Dialog", _node.options[i].endDialog);
                _node.options[i].transform = (Transform)EditorGUILayout.ObjectField(_node.options[i].transform, typeof(Transform), true);
                NodeEditorGUILayout.PortField(new GUIContent($"Option# {i + 1} events"), _node.GetPort($"output {i}"));
                EditorGUILayout.EndVertical();
            }

            if (_node.options.Count < _node.count)
            {
                if (GUILayout.Button("Add"))
                {
                    _node.AddDynamicOutput(typeof(NarrativeNode), Node.ConnectionType.Multiple, Node.TypeConstraint.Inherited, $"output {_node.options.Count}");
                    _node.options.Add(new DialogNodeOption());
                }
            }

            if (_node.haveExit)
                NodeEditorGUILayout.PortField(new GUIContent("Exit events"), _node.GetPort($"exit"));

            // Apply property modifications
            serializedObject.ApplyModifiedProperties();
            EditorUtility.SetDirty(_node);
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