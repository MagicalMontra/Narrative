#if UNITY_EDITOR
using UnityEditor;

namespace SETHD.Narrative.DialogOption
{
    public class DialogOptionDatabaseLoader
    {
        public static DialogOptionDatabase Load()
        {
            return AssetDatabase.LoadAssetAtPath<DialogOptionDatabase>("Assets/Narrative/DialogOption/Database/DialogOptionDatabase.asset");
        }
    }
}
#endif