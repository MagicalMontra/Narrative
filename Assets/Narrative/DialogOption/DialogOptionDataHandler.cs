using Zenject;

namespace SETHD.Narrative.DialogOption
{
    public class DialogOptionDataHandler
    {
        [Inject] private DialogOptionDatabase _database;

        public DialogOptionData Handle(string id)
        {
            DialogOptionData databaseData = _database.data.Find(data => data.id == id);
            DialogOptionData runtimeData = null;
            
            if (databaseData != null)
                runtimeData = new DialogOptionData(databaseData);
            
            return runtimeData;
        }
    }
}