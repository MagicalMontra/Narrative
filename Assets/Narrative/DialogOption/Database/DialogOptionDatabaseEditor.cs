using nanoid;
using UnityEditor;
using UnityEngine;

namespace SETHD.Narrative.DialogOption
{
    [CustomEditor(typeof(DialogOptionDatabase))]
    public class DialogOptionDatabaseEditor : Editor
    {
        private DialogOptionDatabase _database;
        private DialogOptionData _newData = new DialogOptionData();

        private string _searchString = "";
        private string _oldName;
        private bool _debugToggle;
        private void OnEnable()
        {
            _database = (DialogOptionDatabase)target;
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
        }

        private void DrawCreateTab()
        {
            DrawHeaderTab("Create Dialog Option");
            EditorGUILayout.BeginVertical("Button");
            GUILayout.Label("Dialog Name", EditorStyles.largeLabel);
            _newData.name = EditorGUILayout.TextField(_newData.name);

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
                    _newData.options.Add("");
                }
                
            }
            else
                EditorGUILayout.HelpBox("You reached the maximum capacity of options", MessageType.Info);

            
            for (int i = 0; i < _newData.options.Count; i++)
            {
                GUILayout.Label($"Option#{i}: {_newData.options[i]}", EditorStyles.largeLabel);
                _newData.options[i] = EditorGUILayout.TextArea(_newData.options[i]);
                
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button($"Clear {_newData.options[i]}", EditorStyles.toolbarButton))
                    _newData.options[i] = "";
                
                if (GUILayout.Button($"Remove {_newData.options[i]}", EditorStyles.toolbarButton))
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
                GUILayout.Label("Options", EditorStyles.largeLabel);
                for (int j = 0; j < _database.data[i].options.Count; j++)
                {
                    EditorGUILayout.BeginVertical("Button");
                    GUILayout.Label($"Option#{j}: {_database.data[i].options[j]}", EditorStyles.largeLabel);
                    _database.data[i].options[j] = EditorGUILayout.TextArea(_database.data[i].options[j]);
                    EditorGUILayout.Space(5);
                    EditorGUILayout.BeginHorizontal();
                    if (GUILayout.Button($"Clear {_database.data[i].options[j]}", EditorStyles.toolbarButton))
                        _database.data[i].options[j] = "";
                    
                    if (GUILayout.Button($"Remove {_database.data[i].options[j]}", EditorStyles.toolbarButton))
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