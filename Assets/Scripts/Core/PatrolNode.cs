using UnityEngine;

namespace ForgottenLegends.Core
{
    public class PatrolNode : MonoBehaviour
    {
        public PatrolNode LinkedNode => m_LinkedNode;
        [SerializeField] private PatrolNode m_LinkedNode = null;

        private void OnDrawGizmos()
        {
            Gizmos.DrawSphere(transform.position, 0.5f);
        }

        private void OnDrawGizmosSelected()
        {
            if (m_LinkedNode != null)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(transform.position, m_LinkedNode.transform.position);
            }
        }
    }
}