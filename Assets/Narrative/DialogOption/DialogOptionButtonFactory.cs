using UnityEngine;
using Zenject;

namespace SETHD.Narrative.DialogOption
{
    public class DialogOptionButtonFactory : IFactory<Object, Transform, DialogOptionButton>
    {
        private DiContainer _container;
        public DialogOptionButtonFactory(DiContainer container)
        {
            _container = container;
        }
        public DialogOptionButton Create(Object prefab, Transform parent)
        {
            return _container.InstantiatePrefabForComponent<DialogOptionButton>(prefab, parent);
        }
    }
}