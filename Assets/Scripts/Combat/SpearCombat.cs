using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class SpearCombat : CombatScript
{
    public override WeaponType WeaponType => WeaponType.Spear;
    private const float AUDIO_DELAY = 0.1f;
    private float m_BlockedRecently;

    public SpearCombat(Animator animator) : base(animator)
    {
        m_Unsheath = Resources.Load<AudioClip>("Audio/SFX/Unsheath");
        m_Sheath = Resources.Load<AudioClip>("Audio/SFX/Sheath");
    }

    public override void Execute()
    {
        HandleFastAttack();
    }

    public override void OnWeaponSheath()
    {
        if (Player.Instance.CharacterStats.InCombat)
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

    /// <summary>
    /// Does nothing
    /// </summary>
    public override void PostExecute()
    {
        if(m_BlockedRecently > 0)
        {
            m_BlockedRecently -= Time.deltaTime;
        }
    }

    private void HandleFastAttack()
    {
        if (m_BlockedRecently > 0f)
        {
            return;
        }

        if (m_InputHandler.GetAttackDown())
        {
            m_HoldTime += Time.deltaTime;
        }
        if (m_InputHandler.GetAttackUp() && m_HoldTime > 0)
        {
            ResetTime();
            MeleeWeapon.AttackAllowed = true;
            m_AttackType = AttackType.Fast;
            m_Animator.CrossFade($"Spear Stab", 0.1f);
            //m_SwingAudioSource.PlayDelayed(AUDIO_DELAY);
            m_BlockedRecently = 1f;
        }
    }
}
