using ForgottenLegends.Core;
using UnityEngine;

namespace ForgottenLegends.AI
{
    [CreateAssetMenu(fileName = "PatrolState", menuName = "AI/States/Patrol")]
    public class AiPatrol : AiState
    {
        public float destinationTolerance = 1f;
        private PatrolNode m_StartingNode;
        private PatrolNode m_CurrentNode;

        public override bool EnterState(StateMachine stateMachine, float deltaTime)
        {
            PatrolNode[] patrolNodes = GameObject.FindObjectsOfType<PatrolNode>();
            float minDistance = 25f;
            PatrolNode nearestNode = null;
            foreach(var patrolNode in patrolNodes)
            {
                float dist = Vector3.Distance(stateMachine.transform.position, patrolNode.transform.position);
                if (dist < minDistance)
                {
                    minDistance = dist;
                    nearestNode = patrolNode;
                }
            }
            if(nearestNode != null)
            {
                m_StartingNode = nearestNode;
            }
            if(m_StartingNode == null)
            {
                UnityEngine.Debug.LogError($"No starting node found.");
                return false;
            }
            m_CurrentNode = m_StartingNode;
            return base.EnterState(stateMachine, deltaTime);
        }

        public override void Execute(float deltaTime)
        {
            float distance = Vector3.Distance(m_StateMachine.transform.position, m_CurrentNode.transform.position);
            if (distance <= destinationTolerance)
            {
                m_StateMachine.StopPathing();
                if(m_CurrentNode.LinkedNode != null)
                {
                    m_CurrentNode = m_CurrentNode.LinkedNode;
                    return;
                }
                if(shouldRepeat == true)
                {
                    m_CurrentNode = m_StartingNode;
                }
                return;
            }
            m_StateMachine.PathTo(m_CurrentNode.transform.position);
        }
    }
}
