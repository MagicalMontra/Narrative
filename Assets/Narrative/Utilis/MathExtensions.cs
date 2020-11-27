using UnityEngine;

namespace SETHD.Narrative
{
    public static class MathExtensions
    {
        public static Vector3 GetRadiantPosition(Transform transform, float radius, float theta)
        {
            var center = transform.position;
            var facingAngles = transform.eulerAngles.y;
            var radiant = (facingAngles * -Mathf.Deg2Rad) + (theta);
            var desiredPos = Vector3.zero;
            desiredPos.x = Mathf.Cos(radiant) * radius + center.x;
            desiredPos.y = center.y;
            desiredPos.z = Mathf.Sin(radiant) * radius + center.z;
            return desiredPos;
        }
        public static Vector3 GetFacingRadiant(Transform transform, float radius)
        {
            var center = transform.position;
            var facingAngles = transform.eulerAngles.y;
            var radiant = (facingAngles * -Mathf.Deg2Rad) + (Mathf.PI * 0.5f);
            var desiredPos = Vector3.zero;
            desiredPos.x = Mathf.Cos(radiant) * radius + center.x;
            desiredPos.y = center.y;
            desiredPos.z = Mathf.Sin(radiant) * radius + center.z;
            return desiredPos;
        }
        public static Vector3 GetShiftFacingRadiant(Transform transform, float radius, float shiftY, float shiftZ)
        {
            var center = transform.position;
            var facingAngles = transform.eulerAngles;
            var radHor = (facingAngles.y * -Mathf.Deg2Rad) + ((Mathf.PI * 0.5f) + shiftY);
            var radVert = (facingAngles.z * -Mathf.Deg2Rad) + ((Mathf.PI * 0.5f) + shiftZ);
            var desiredPos = Vector3.zero;
            desiredPos.x = Mathf.Cos(radHor) * radius + center.x;
            desiredPos.y = Mathf.Cos(radVert) * radius + center.y;
            desiredPos.z = Mathf.Sin(radHor) * radius + center.z;
            return desiredPos;
        }
    }
}