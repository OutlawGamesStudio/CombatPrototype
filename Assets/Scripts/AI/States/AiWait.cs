using System;

namespace ForgottenLegends.AI
{
    [Serializable]
    public class AiWait : AiState
    {
        [NonSerialized] protected float m_CurrentWaitTime = 0;
        public float WaitSeconds = 0;

        public AiWait()
        {
            m_CurrentWaitTime = 0;
        }

        public override void Execute(float deltaTime)
        {
            m_StateMachine.StopPathing();
            if (m_CurrentWaitTime >= WaitSeconds)
            {
                UnityEngine.Debug.Log($"Exiting Idle State after {WaitSeconds}");
                m_CurrentWaitTime = 0;
                CompleteState();
                return;
            }
            m_CurrentWaitTime += deltaTime;
        }
    }
}