using System.Collections.Generic;
using UnityEngine;

namespace SETHD.Narrative
{
    public static class VectorExtensions
    {
        public static Vector3 FindCenter(params Transform[] points)
        {
            var totalX = 0f;
            var totalZ = 0f;

            for (int i = 0; i < points.Length; i++)
            {
                totalX += points[i].transform.position.x;
                totalZ += points[i].transform.position.z;
            }

            var centerX = totalX / points.Length;
            var centerZ = totalZ / points.Length;
            
            return new Vector3(centerX, 0, centerZ);
        }
    }
}