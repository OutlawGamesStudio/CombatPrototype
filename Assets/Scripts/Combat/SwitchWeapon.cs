using System;
using UnityEngine;

public class SwitchWeapon : CombatScript
{
    public override WeaponType WeaponType => throw new NotImplementedException();
    private WeaponType m_CurrentWeaponType;

    public SwitchWeapon(Animator animator) : base(animator)
    {

    }

    public override void Execute()
    {
        if(m_InputHandler.MouseScroll < -0.1f && m_CurrentWeaponType > WeaponType.Fists)
        {
            m_CurrentWeaponType--;
        }
        if (m_InputHandler.MouseScroll > 0.1f && m_CurrentWeaponType < WeaponType.Spear)
        {
            m_CurrentWeaponType++;
        }
        Combat.SetWeaponType(m_CurrentWeaponType);
    }

    public override void OnWeaponSheath()
    {
        throw new NotImplementedException();
    }

    public override void PostExecute()
    {
        throw new NotImplementedException();
    }
}
