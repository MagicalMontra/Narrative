using System.Collections.Generic;
using UnityEngine;

namespace SETHD.Narrative.DialogOption
{
    [CreateAssetMenu(menuName = "Narrative/Dialog Option/Create DialogOptionDatabase", fileName = "DialogOptionDatabase", order = 0)]
    public class DialogOptionDatabase : ScriptableObject
    {
        public int maximumOption = 3;
        public List<DialogOptionData> data = new List<DialogOptionData>();
    }
}