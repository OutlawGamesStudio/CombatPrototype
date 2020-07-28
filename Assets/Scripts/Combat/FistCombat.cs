using UnityEngine;

public class FistCombat : CombatScript
{
    public override WeaponType WeaponType => WeaponType.Fists;

    private const float MIN_HOLD_TIME = 0.25f;

    public FistCombat(Animator animator, AnimationScript animationScript) : base(animator, animationScript)
    {

    }

    public override void Execute()
    {
        HandleFastAttack();
    }

    private void HandleFastAttack()
    {
        if (m_InputHandler.GetAttackDown())
        {
            m_HoldTime += Time.deltaTime;
        }
        if (m_InputHandler.GetAttackUp() && m_HoldTime > MIN_HOLD_TIME)
        {
            Debug.Log($"Hold time = {m_HoldTime}");
            StartAttack();
        }
    }

    public void StartAttack()
    {
        ResetTime();
        MeleeWeapon.AttackAllowed = true;
        m_AttackType = AttackType.Fast;
        m_CombatHandler.PlayFastAttack(WeaponType);
    }

    public override void OnWeaponSheath()
    {
        // Do nothing, yet.
    }

    public override void PostExecute()
    {
        //throw new NotImplementedException();
    }
}
