using UnityEngine;

[CreateAssetMenu(fileName = "IdleState", menuName = "AI/States/Idle")]
public class AiWait : AiState
{
    public float WaitSeconds = 0;
    public float m_CurrentWaitTime = 0;

    private void Awake()
    {
        m_CurrentWaitTime = 0;
    }

    public override void Execute(float deltaTime)
    {
        if(m_CurrentWaitTime >= WaitSeconds)
        {
            Debug.Log($"Exiting Idle State after {WaitSeconds}");
            m_CurrentWaitTime = 0;
            CompleteState();
            return;
        }
        m_CurrentWaitTime += deltaTime;
    }
}
