#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace SETHD.Narrative.DialogOption
{
    public class DialogOptionSearchWindow : EditorWindow
    {
        private static DialogOptionDatabase _database;
        private static DialogOptionNode _node;
        
        private Vector2 _scrollValue;
        
        private string _value;
        public static void Open(DialogOptionNode node)
        {
            _node = node;
            _database = DialogOptionDatabaseLoader.Load();
            DialogOptionSearchWindow window = CreateInstance<DialogOptionSearchWindow>();
            window.titleContent = new GUIContent("Dialog Option Search");
            Vector2 mouse = GUIUtility.GUIToScreenPoint(Event.current.mousePosition);
            Rect r = new Rect(mouse.x - 450, mouse.y + 10, 10, 10);
            window.ShowAsDropDown(r, new Vector2(500, 300));
        }
        
        public void OnGUI()
        {
            if (Application.isPlaying)
                return;
            
            EditorGUILayout.BeginHorizontal("Box");
            EditorGUILayout.LabelField("Search: ", EditorStyles.boldLabel);
            _value = EditorGUILayout.TextField(_value);
            EditorGUILayout.EndHorizontal();

            GetSearchResult();
        }
        private void GetSearchResult()
        {
            if (string.IsNullOrEmpty(_value))
                return;

            EditorGUILayout.BeginVertical();
            _scrollValue = EditorGUILayout.BeginScrollView(_scrollValue);

            for (int i = 0; i < _database.data.Count; i++)
            {
                if (_database.data[i].name.Contains(_value) || _database.data[i].id.Contains(_value))
                {
                    EditorGUILayout.BeginVertical("Button");
                    GUILayout.Label(_database.data[i].name);
                    EditorGUILayout.EndVertical();
                    EditorGUILayout.BeginVertical("Button");
                    EditorGUILayout.BeginHorizontal();
                    var select = new GUIContent(EditorGUIUtility.IconContent("d_FilterSelectedOnly"));

                    if (GUILayout.Button(select, GUILayout.MaxHeight(20), GUILayout.MaxWidth(20)))
                    {
                        _node.dialogId = _database.data[i].id;
                        _node.haveExit = _database.data[i].haveExit;
                        _node.count = _database.data[i].count;

                        Close();
                    }
                    
                    EditorGUILayout.SelectableLabel(_database.data[i].id, EditorStyles.textField);
                    for (int j = 0; j < _database.data[i].options.Count; j++)
                        EditorGUILayout.SelectableLabel(_database.data[i].options[j].value, EditorStyles.textArea);
                    
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.EndVertical();
                }
            }
        
            EditorGUILayout.EndScrollView();
            EditorGUILayout.EndVertical();
        }
    }
}
#endif