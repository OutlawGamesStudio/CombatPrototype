using UnityEngine;

public class FaceState : AiState
{
    public Vector3 facingPosition;
    public float facingSpeed = 1f;

    public bool EnterState(StateMachine stateMachine, Transform transformToFace)
    {
        base.EnterState(stateMachine);
        facingPosition = transformToFace.position;
        return true;
    }

    public override void Execute(NPC npc)
    {
        var rotation = Quaternion.LookRotation(facingPosition);
        m_StateMachine.transform.rotation = Quaternion.Slerp(m_StateMachine.transform.rotation, rotation, Time.deltaTime * facingSpeed);

        Debug.DrawRay(m_StateMachine.transform.position, facingPosition, Color.red);

        Vector3 forward = m_StateMachine.transform.forward;
        Vector3 toOther = (facingPosition - m_StateMachine.transform.position).normalized;
        float dot = Vector3.Dot(forward, toOther);

        if (dot < 0.7f)
        {
            ExitState();
        }
    }

    public override bool ExitState()
    {
        base.ExitState();
        return true;
    }
}
