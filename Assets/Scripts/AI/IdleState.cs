using UnityEngine;

[CreateAssetMenu(fileName = "IdleState", menuName = "States/Idle")]
public class IdleState : AiState
{
    private float MAX_WAIT_TIME = 1.1f;
    private float maxWaitTime = 0;
    private float currentWaitTime = 0;

    public override bool EnterState(StateMachine stateMachine)
    {
        base.EnterState(stateMachine);
        currentWaitTime = 0;
        maxWaitTime = Random.Range(1f, MAX_WAIT_TIME);
        return true;
    }

    public override void Execute(NPC npc)
    {
        if (currentWaitTime < maxWaitTime)
        {
            currentWaitTime += Time.deltaTime;
            if (currentWaitTime >= maxWaitTime)
            {
                WalkState walkState = (WalkState)ScriptableObject.CreateInstance<WalkState>();
                m_StateMachine.EnterState(walkState);
            }
        }
    }

    public override bool ExitState()
    {
        base.ExitState();
        return true;
    }
}
