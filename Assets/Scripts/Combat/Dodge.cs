using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Dodge : CombatScript
{
    public override WeaponType WeaponType => throw new NotImplementedException();

    public Dodge(Animator animator, Combat combat) : base(animator, combat)
    {

    }

    public override void Execute()
    {
        HandleDodge();
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

    private void HandleDodge()
    {
        if (m_InputHandler.GetDodge())
        {
            ResetTime();
            int randAnim = Random.Range(1, 3);
            m_Animator.CrossFade($"Dodge{randAnim}", 0.1f);
        }
    }
}
