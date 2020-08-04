using UnityEngine;

namespace ForgottenLegends.AI
{
    [CreateAssetMenu(fileName = "FaceState", menuName = "AI/States/Face")]
    public class AiFace : AiWait
    {
        public Vector3 FacePosition;
        private Vector3 m_CurrentPosition;

        public override bool EnterState(StateMachine stateMachine, float deltaTime)
        {
            m_CurrentPosition = stateMachine.transform.position;
            if (WaitSeconds < 1)
            {
                WaitSeconds = 5;
            }
            return base.EnterState(stateMachine, deltaTime);
        }

        public override void Execute(float deltaTime)
        {
            m_StateMachine.PathTo(m_CurrentPosition);
            m_StateMachine.FacePosition(FacePosition);
            Vector3 dir = FacePosition - m_StateMachine.transform.position;
            if (Vector3.Dot(dir, m_StateMachine.transform.forward) > 0.0f)
            {
                if (WaitSeconds > 0 && m_CurrentWaitTime >= WaitSeconds)
                {
                    CompleteState();
                    return;
                }
                CompleteState();
                return;
            }
            base.Execute(deltaTime);
        }
    }
}