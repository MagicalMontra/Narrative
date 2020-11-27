using System;
using System.Collections.Generic;
using nanoid;

namespace SETHD.Narrative.DialogOption
{
    [Serializable]
    public class DialogOptionData
    {
        public int count => options.Count;
        public string id;
        public string name;
        public List<OptionData> options = new List<OptionData>();
        
        public DialogOptionData(){}

        public DialogOptionData(DialogOptionData data)
        {
            id = data.id;
            name = data.name;

            for (int i = 0; i < data.options.Count; i++)
                options.Add(data.options[i]);

        }
    }

    [Serializable]
    public class OptionData
    {
        public bool exitOnSelect;
        public string value;
    }
}