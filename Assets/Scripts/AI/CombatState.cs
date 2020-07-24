using UnityEngine;

[CreateAssetMenu(fileName = "CombatState", menuName = "States/Combat")]
public class CombatState : AiState
{
    public Player targetCharacter;

    public override bool EnterState(StateMachine stateMachine)
    {
        base.EnterState(stateMachine);
        return true;
    }

    public override void Execute(NPC npc)
    {
        Vector3 npcPos = npc.transform.position;
        Vector3 targetPos = targetCharacter.transform.position;

        float destinationTolerance = 1f, maxDistance = 10f;
        if (Vector3.Distance(npcPos, targetPos) > maxDistance || targetCharacter.CharacterStats.IsDead)
        {
            ExitState();
            return;
        }

        if (Vector3.Distance(npcPos, targetPos) <= destinationTolerance)
        {
            m_StateMachine.NPC.NPCAnimator.AttackAnimation();
            return;
        }


        PathTo(targetCharacter.transform.position);
    }
}
