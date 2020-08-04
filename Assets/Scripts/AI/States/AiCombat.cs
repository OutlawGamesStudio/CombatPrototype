using UnityEngine;

namespace ForgottenLegends.AI
{
    [CreateAssetMenu(fileName = "CombatState", menuName = "AI/States/Combat")]
    public class AiCombat : AiState
    {
        public Actor TargetActor;
        public float destinationTolerance = 1f;

        public WeaponType WeaponType { get; private set; }
        private NpcCombat m_NpcCombat;
        private float m_CombatWaitTime = 0;

        public void InitiateCombat(NpcCombat npcCombat, WeaponType weaponType, Actor targetActor)
        {
            TargetActor = targetActor;
            WeaponType = weaponType;
            m_NpcCombat = npcCombat;
            shouldReturnToPreviousState = true;
        }

        private bool IsTargetDead()
        {
            if (TargetActor.ActorData.CharacterStats.CurrentHealth <= 0 || TargetActor.ActorData.CharacterStats.IsDead == true)
            {
                return true;
            }
            return false;
        }

        public override void Execute(float deltaTime)
        {
            float distance = Vector3.Distance(m_StateMachine.transform.position, TargetActor.transform.position);
            if (IsTargetDead() || distance > 10)
            {
                TerminateState();
                return;
            }

            if (m_CombatWaitTime > 0)
            {
                m_CombatWaitTime -= deltaTime;
            }

            Vector3 targetPos = TargetActor.transform.position;
            if (distance <= destinationTolerance)
            {
                m_StateMachine.StopPathing();
                m_StateMachine.FacePosition(targetPos);
                if (m_CombatWaitTime <= 0f)
                {
                    m_CombatWaitTime = 1f;
                    m_NpcCombat.StartAttack(WeaponType);
                }
                if (IsTargetDead())
                {
                    CompleteState();
                }
                return;
            }
            m_StateMachine.PathTo(targetPos);
        }
    }
}