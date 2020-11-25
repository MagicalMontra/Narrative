using System.Collections.Generic;
using UnityEngine;

namespace SETHD.Narrative
{
    public class CameraPositionPointPool
    {
        private List<CameraPositionContainer> _containers = new List<CameraPositionContainer>();
        
        public CameraPositionContainer GetContainer()
        {
            CameraPositionContainer container = null;
            
            for (int i = 0; i < _containers.Count; i++)
            {
                if (!_containers[i].active)
                {
                    container = _containers[i];
                    break;
                }
            }
            
            if (ReferenceEquals(container, null))
                container = new GameObject("Camera Pos Container").AddComponent<CameraPositionContainer>();

            return container;
        }
    }
}