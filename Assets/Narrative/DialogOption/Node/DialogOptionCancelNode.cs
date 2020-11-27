namespace SETHD.Narrative.DialogOption
{
    public class DialogOptionCancelNode : MiddleNode
    {
        public override void Run()
        {
            base.Run();
            SignalBusSingleton.Instance.Fire(new DialogOptionCancelRequest());
            MoveNext();
        }
    }
}