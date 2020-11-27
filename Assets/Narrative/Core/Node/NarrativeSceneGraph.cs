using XNode;

namespace SETHD.Narrative
{
    public class NarrativeSceneGraph : SceneGraph<NarrativeGraph>
    {
        public void Run()
        {
            graph.Start();
        }
    }
}