using System;
using UnityEngine;

public class CombatBlock : CombatScript
{
    public override WeaponType WeaponType => WeaponType.Other;
    private float m_BlockTime = 0f;

    public CombatBlock(Animator animator) : base(animator)
    {
    }

    public override void Execute()
    {
        HandleBlock();
    }

    /// <summary>
    /// Not implemented
    /// </summary>
    public override void OnWeaponSheath()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Not implemented
    /// </summary>
    public override void PostExecute()
    {
        throw new NotImplementedException();
    }

    private void HandleBlock()
    {
        if (m_InputHandler.GetShieldDown() && m_BlockTime <= 0)
        {
            m_Animator.SetBool("Blocking", true);
            m_Animator.CrossFade($"Shield Block", 0.1f);
            m_BlockTime += Time.deltaTime;
        }
        if (m_InputHandler.GetShieldUp())
        {
            m_Animator.SetBool("Blocking", false);
            m_BlockTime = 0;
        }
    }
}
