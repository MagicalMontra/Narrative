using System.Threading.Tasks;
using UnityEngine;

namespace SETHD.Narrative
{
    public class TestCircleRigCloseup : MonoBehaviour
    {
        [Range(-Mathf.PI * 0.75f,Mathf.PI * 0.75f)]
        [SerializeField] private float theta;
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(transform.position, 5f);
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(MathExtensions.GetFacingRadiant(transform, 5f), 0.5f);
            var shiftY = Random.Range(-0.77f, 0.77f);
            var shiftZ = Random.Range(-0.77f, 0.77f);
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(MathExtensions.GetShiftFacingRadiant(transform, 5f, shiftY, shiftZ), 0.5f);
        }
    }
}