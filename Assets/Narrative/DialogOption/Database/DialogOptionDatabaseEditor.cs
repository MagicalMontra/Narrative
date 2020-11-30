using System;
using System.Collections.Generic;
using nanoid;
using UnityEditor;
using UnityEngine;

namespace SETHD.Narrative.DialogOption
{
    [CustomEditor(typeof(DialogOptionDatabase))]
    public class DialogOptionDatabaseEditor : Editor
    {
        private List<string> _exitPopup = new List<string>();
        private List<List<string>> _exitPopups = new List<List<string>>();
        private List<int> _exitValues = new List<int>();
        private List<int> _exitValueComparer = new List<int>();

        private DialogOptionDatabase _database;
        private DialogOptionData _newData = new DialogOptionData();

        private string _searchString = "";
        private string _oldName;
        private bool _debugToggle;
        private int _newDataHaveExit;
        private int _oldNewDataHaveExit;
        private void OnEnable()
        {
            _database = (DialogOptionDatabase)target;
            
            _exitPopup.Clear();
            _exitPopup.Add("No");
            _exitPopup.Add("Yes");

            _exitPopups.Clear();
            _exitValues.Clear();
            _exitValueComparer.Clear();
            
            for (int i = 0; i < _database.data.Count; i++)
            {
                var exitPopup = new List<string>();
                _exitValues.Add(_database.data[i].haveExit ? 1 : 0);
                _exitValueComparer.Add(_database.data[i].haveExit ? 1 : 0);
                for (int j = 0; j < _database.data[i].options.Count; j++)
                {
                    exitPopup.Add("No");
                    exitPopup.Add("Yex");
                }
                
                _exitPopups.Add(exitPopup);
            }
        }

        public override void OnInspectorGUI()
        {
            if (_debugToggle)
            {
                base.OnInspectorGUI();
                EditorGUILayout.BeginVertical("Box");
                DrawGlobalSettings();
                EditorGUILayout.EndVertical();
                return;
            }
            
            EditorGUILayout.BeginVertical("Box");
            DrawHeaderTab("Dialog Option Database");
            DrawGlobalSettings();
            DrawCreateTab();
            DrawSearchTab();
            EditorGUILayout.EndVertical();

            if (GUI.changed)
            {
                serializedObject.ApplyModifiedProperties();
                EditorUtility.SetDirty(_database);
            }
        }

        private void DrawCreateTab()
        {
            DrawHeaderTab("Create Dialog Option");
            EditorGUILayout.BeginVertical("Button");
            GUILayout.Label("Dialog Name", EditorStyles.largeLabel);
            _newData.name = EditorGUILayout.TextField(_newData.name);
            GUILayout.Label("Have an exit option?", EditorStyles.largeLabel);
            _newDataHaveExit = EditorGUILayout.Popup(_newDataHaveExit, _exitPopup.ToArray());

            if (_oldNewDataHaveExit != _newDataHaveExit)
            {
                _oldNewDataHaveExit = _newDataHaveExit;
                _newData.haveExit = Convert.ToBoolean(_newDataHaveExit);
            }

            if (_oldName != _newData.name)
            {
                _oldName = _newData.name;
                _newData.id = $"dialog_option_{_newData.name}_{NanoId.Generate(8)}";
            }
            
            GUILayout.Label("Dialog ID", EditorStyles.largeLabel);
            GUILayout.Label(_newData.id, EditorStyles.largeLabel);
            EditorGUILayout.Space(5);
            EditorGUILayout.EndVertical();
            
            EditorGUILayout.BeginVertical("Button");
            GUILayout.Label("Dialog Options", EditorStyles.largeLabel);

            if (_newData.options.Count < _database.maximumOption)
            {
                if (GUILayout.Button("Add option", EditorStyles.toolbarButton))
                {
                    _newData.options.Add(new OptionData());
                }
                
            }
            else
                EditorGUILayout.HelpBox("You reached the maximum capacity of options", MessageType.Info);

            
            for (int i = 0; i < _newData.options.Count; i++)
            {
                GUILayout.Label($"Option#{i}: {_newData.options[i].value}", EditorStyles.largeLabel);
                GUILayout.Label("Override exit option");
                _newData.options[i].overrideExit = EditorGUILayout.Toggle( _newData.options[i].overrideExit);
                _newData.options[i].value = EditorGUILayout.TextArea(_newData.options[i].value);
                
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button($"Clear {_newData.options[i].value}", EditorStyles.toolbarButton))
                    _newData.options[i].value = "";
                
                if (GUILayout.Button($"Remove {_newData.options[i].value}", EditorStyles.toolbarButton))
                    _newData.options.RemoveAt(i);
                
                EditorGUILayout.EndHorizontal();
            }
            
            EditorGUILayout.Space(5);
            EditorGUILayout.EndVertical();
            
            if (GUILayout.Button($"Add {_newData.name}"))
            {
                _database.data.Add(_newData);
                _newData = new DialogOptionData();
                EditorUtility.SetDirty(_database);
                serializedObject.ApplyModifiedProperties();
            }
            EditorGUILayout.Space(5);
        }

        private void DrawSearchTab()
        {
            DrawHeaderTab("Search for dialog");
            _searchString = EditorGUILayout.TextField(_searchString, EditorStyles.toolbarSearchField);
            if (string.IsNullOrEmpty(_searchString))
                return;
            
            for (int i = 0; i < _database.data.Count; i++)
            {
                if (!_database.data[i].name.Contains(_searchString))
                    continue;
                
                EditorGUILayout.BeginVertical("Box");
                EditorGUILayout.BeginVertical("Button");
                GUILayout.Label($"Dialog: {_database.data[i].name}", EditorStyles.largeLabel);
                EditorGUILayout.EndVertical();
                EditorGUILayout.BeginVertical("Button");
                GUILayout.Label($"Dialog ID: {_database.data[i].id}", EditorStyles.largeLabel);
                if (GUILayout.Button($"Copy ID", EditorStyles.toolbarButton))
                    EditorGUIUtility.systemCopyBuffer = _database.data[i].id;
                
                EditorGUILayout.Space(5);
                EditorGUILayout.EndVertical();
                
                EditorGUILayout.BeginVertical("Button");
                GUILayout.Label("Have an exit option?", EditorStyles.largeLabel);
                _exitValues[i] = EditorGUILayout.Popup(_exitValues[i], _exitPopup.ToArray());
                EditorGUILayout.Space(5);
                EditorGUILayout.EndVertical();

                if (_exitValues[i] != _exitValueComparer[i])
                {
                    _exitValueComparer[i] = _exitValues[i];
                    _database.data[i].haveExit = Convert.ToBoolean(_exitValues[i]);
                }

                EditorGUILayout.BeginVertical("Button");
                GUILayout.Label("Options", EditorStyles.largeLabel);
                for (int j = 0; j < _database.data[i].options.Count; j++)
                {
                    EditorGUILayout.BeginVertical("Button");
                    GUILayout.Label($"Option#{j}: {_database.data[i].options[j].value}", EditorStyles.largeLabel);
                    GUILayout.Label("Override exit option");
                    _database.data[i].options[j].overrideExit = EditorGUILayout.Toggle(_database.data[i].options[j].overrideExit);

                    if (_database.data[i].options.Exists(o => o.overrideExit && o != _database.data[i].options[j]))
                    {
                        var option = _database.data[i].options.FindIndex(o => o.overrideExit && o != _database.data[i].options[j]);

                        if (option != j)
                            _database.data[i].options[j].overrideExit = false;
                    }
                    
                    _database.data[i].options[j].value = EditorGUILayout.TextArea(_database.data[i].options[j].value);
                    EditorGUILayout.Space(5);
                    EditorGUILayout.BeginHorizontal();
                    if (GUILayout.Button($"Clear {_database.data[i].options[j].value}", EditorStyles.toolbarButton))
                        _database.data[i].options[j].value = "";
                    
                    if (GUILayout.Button($"Remove {_database.data[i].options[j].value}", EditorStyles.toolbarButton))
                        _database.data[i].options.RemoveAt(j);
                    
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.Space(5);
                    EditorGUILayout.EndVertical();

                }
                
                EditorGUILayout.Space(5);
                if (GUILayout.Button($"Remove {_database.data[i].name}", EditorStyles.toolbarButton))
                    _database.data.RemoveAt(i);
                    
                EditorGUILayout.Space(5);
                EditorGUILayout.EndVertical();
                
                EditorGUILayout.EndVertical();
            }
            

        }
        private void DrawGlobalSettings()
        {
            EditorGUILayout.BeginVertical("Button");
            GUILayout.Label("Debug Mode", EditorStyles.largeLabel);
            _debugToggle = EditorGUILayout.Toggle(_debugToggle);
            EditorGUILayout.EndVertical();
            EditorGUILayout.BeginVertical("Button");
            GUILayout.Label("Maximum Option Count", EditorStyles.largeLabel);
            _database.maximumOption = EditorGUILayout.IntSlider(_database.maximumOption, 1, 3);
            EditorGUILayout.Space(5);
            EditorGUILayout.EndVertical();
        }
        private void DrawHeaderTab(string title)
        {
            EditorGUILayout.BeginVertical("Button");
            GUILayout.Label(title, EditorStyles.largeLabel);
            EditorGUILayout.EndVertical();
        }
    }
}