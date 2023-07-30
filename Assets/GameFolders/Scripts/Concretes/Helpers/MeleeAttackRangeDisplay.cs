using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameProject3.Helpers
{
    public class MeleeAttackRangeDisplay : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            OnDrawGizmosSelected();
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;

            Gizmos.DrawSphere(this.transform.position,1f);
        }
    }
}

