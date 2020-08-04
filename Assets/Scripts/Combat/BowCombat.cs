using ForgottenLegends.Character;
using UnityEngine;

public class BowCombat : CombatScript
{
    public override WeaponType WeaponType => WeaponType.Bow;

    public BowCombat(Animator animator, Combat combat) : base(animator, combat)
    {
        // Keep it as the Sword sfx for now.
        m_Unsheath = Resources.Load<AudioClip>("Audio/SFX/Unsheath");
        m_Sheath = Resources.Load<AudioClip>("Audio/SFX/Sheath");
    }

    public override void Execute()
    {
        HandleBowFire();
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

    public override void PostExecute() { }

    private void HandleBowFire()
    {
        if (m_InputHandler.GetAttackDown() && m_HoldTime <= 0)
        {
            MeleeWeapon.AttackAllowed = true;
            m_AttackType = AttackType.Fast;
            m_Animator.SetBool("BowFire", false);
            m_Animator.CrossFade($"Bow Draw", 0.1f);
            m_HoldTime += m_InputHandler.GetAttackHoldTime();
        }
        if (m_InputHandler.GetAttackUp())
        {
            m_Animator.SetBool("BowFire", true);
            ResetTime();
        }
    }
}
