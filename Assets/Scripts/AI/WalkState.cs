using UnityEngine;

[CreateAssetMenu(fileName = "WalkState", menuName = "States/Walk")]
public class WalkState : AiState
{
    public Vector3 walkPosition;

    public override bool EnterState(StateMachine stateMachine)
    {
        base.EnterState(stateMachine);
        return true;
    }

    public override void Execute(NPC npc)
    {
        Vector3 npcPos = npc.transform.position;

        float destinationTolerance = 1f;
        if (Vector3.Distance(npcPos, walkPosition) <= destinationTolerance)
        {
            ExitState();
            return;
        }

        PathTo(walkPosition);
    }
}
