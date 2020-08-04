using ForgottenLegends.Character;
using UnityEngine;

namespace ForgottenLegends.Combat
{
    public class SwordCombat : CombatScript
    {
        public override WeaponType WeaponType => WeaponType.Sword;

        private const float MIN_HOLD_TIME = 1f;
        private const float AUDIO_DELAY = 0.1f;

        private float m_BlockedRecently;
        private AudioSource m_SwingAudioSource;
        private float m_StrongAttackBeingPerformed;

        public SwordCombat(Animator animator, AudioSource swingSource, AnimationScript combat) : base(animator, combat)
        {
            m_SwingAudioSource = swingSource;
            m_Unsheath = Resources.Load<AudioClip>("Audio/SFX/Unsheath");
            m_Sheath = Resources.Load<AudioClip>("Audio/SFX/Sheath");
        }

        public override void OnWeaponSheath()
        {
            if (Player.Instance.ActorData.CharacterStats.InCombat)
            {
                Combat.AudioSource.clip = m_Unsheath;
                m_Animator.CrossFade("Combat Withdraw Sword", 0.1f);
            }
            else
            {
                Combat.AudioSource.clip = m_Sheath;
                m_Animator.CrossFade("Combat Sheath Sword", 0.1f);
            }
        }

        public override void Execute()
        {
            HandleFastAttack();
            HandleStrongAttack();
            if (m_BlockedRecently > 0)
            {
                m_BlockedRecently -= Time.deltaTime;
            }
        }

        public override void PostExecute()
        {
            if (m_StrongAttackBeingPerformed > 0)
            {
                m_StrongAttackBeingPerformed -= Time.deltaTime;
            }
        }

        private void HandleFastAttack()
        {
            if (WeaponType != WeaponType.Sword && WeaponType != WeaponType.Spear)
            {
                return;
            }
            if (m_BlockedRecently > 0f)
            {
                return;
            }

            if (m_InputHandler.GetAttackDown())
            {
                m_HoldTime += Time.deltaTime;
            }
            if (m_InputHandler.GetAttackUp() && m_HoldTime > 0 && m_HoldTime < MIN_HOLD_TIME)
            {
                StartAttack();
            }
        }

        public void StartAttack()
        {
            ResetTime();
            MeleeWeapon.AttackAllowed = true;
            m_AttackType = AttackType.Fast;
            m_CombatHandler.PlayFastAttack(WeaponType);
            m_SwingAudioSource.PlayDelayed(AUDIO_DELAY);
            m_BlockedRecently = 1f;
        }

        private void HandleStrongAttack()
        {
            if (WeaponType != WeaponType.Sword && WeaponType != WeaponType.Spear)
            {
                return;
            }
            if (m_StrongAttackBeingPerformed > 0)
            {
                return;
            }

            if (m_InputHandler.GetAttackDown())
            {
                m_HoldTime += Time.deltaTime;
            }
            if (m_HoldTime > 0 && m_HoldTime >= MIN_HOLD_TIME && m_StrongAttackBeingPerformed <= 0)
            {
                PlayerMovement.PauseControls(1);
                ResetTime();
                MeleeWeapon.AttackAllowed = true;
                m_AttackType = AttackType.Strong;
                m_CombatHandler.PlayStrongAttack(WeaponType);
                m_StrongAttackBeingPerformed = 1.5f;
                m_SwingAudioSource.PlayDelayed(AUDIO_DELAY);
            }
        }
    }
}