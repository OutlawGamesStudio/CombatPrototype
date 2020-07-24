using UnityEngine;

public enum AttackType
{
    None,
    Dodge,
    SwordFast,
    SwordStrong
};

public class Combat : AnimationScript
{
    private const float MIN_HOLD_TIME = 1f;

    [SerializeField] private AttackType m_AttackType = AttackType.None;
    [SerializeField] private float m_HoldTime = 0f;
    private InputHandler m_InputHandler;
    private float m_StrongAttackBeingPerformed;

    protected override void Start()
    {
        base.Start();
        ResetTime();
        m_InputHandler = InputHandler.Instance;
    }

    private void ResetTime()
    {
        m_HoldTime = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        HandleDodge();
        HandleFastAttack();
        HandleStrongAttack();
        if(m_StrongAttackBeingPerformed > 0)
        {
            m_StrongAttackBeingPerformed -= Time.deltaTime;
        }
    }

    private void HandleDodge()
    {
        if (m_InputHandler.GetDodge())
        {
            ResetTime();
            int randAnim = Random.Range(1, 3);
            m_AttackType = AttackType.Dodge;
            m_Animator.CrossFade($"Dodge{randAnim}", 0.1f);
        }
    }

    private void HandleFastAttack()
    {
        if (m_InputHandler.GetAttackDown())
        {
            m_HoldTime += m_InputHandler.GetAttackHoldTime();
        }
        if (m_InputHandler.GetAttackUp() && m_HoldTime > 0 && m_HoldTime < MIN_HOLD_TIME)
        {
            ResetTime();
            m_AttackType = AttackType.SwordFast;
            m_Animator.CrossFade($"Fast Attack", 0.1f);
        }
    }

    private void HandleStrongAttack()
    {
        if (m_StrongAttackBeingPerformed > 0)
        {
            return;
        }

        if (m_InputHandler.GetAttackDown())
        {
            m_HoldTime += m_InputHandler.GetAttackHoldTime();
        }
        if (m_HoldTime > 0 && m_HoldTime >= MIN_HOLD_TIME)
        {
            PlayerMovement.PauseControls(1);
            ResetTime();
            m_AttackType = AttackType.SwordStrong;
            m_Animator.CrossFade($"Strong Attack", 0.1f);
            m_StrongAttackBeingPerformed = 0.5f;
        }
    }
}
