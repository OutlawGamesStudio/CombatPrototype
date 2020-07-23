using UnityEngine;
using UnityEngine.InputSystem;

public enum AttackType
{
    None,
    Dodge,
    SwordFast,
    SwordStrong
};

public class Combat : AnimationScript
{
    private const float MAX_WAIT_TIME = 0.5f;
    private const float MIN_HOLD_TIME = 0.25f;
    private const float MAX_HOLD_TIME = 0.5f;

    [SerializeField] private AttackType m_AttackType = AttackType.None;
    private float m_UpdateTime = 0;
    private float m_WaitTime;
    private float m_HoldTime = 0f;
    private InputHandler m_InputHandler;

    protected override void Start()
    {
        base.Start();
        ResetTime();
        m_InputHandler = InputHandler.Instance;
    }

    private void ResetTime()
    {
        m_WaitTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_AttackType != AttackType.None && m_WaitTime >= 0)
        {
            m_WaitTime += Time.deltaTime;
            if (m_WaitTime >= MAX_WAIT_TIME)
            {
                m_AttackType = AttackType.None;
            }
        }
        HandleDodge();
        HandleFastAttack();
        HandleStrongAttack();
        m_UpdateTime += Time.deltaTime;
        if (m_UpdateTime > MAX_HOLD_TIME)
        {
            m_UpdateTime = 0;
            ResetTime();
        }
    }

    private void HandleDodge()
    {
        if (IsAttackButtonReleased("Dodge"))
        {
            ResetTime();
            int randAnim = Random.Range(1, 3);
            m_AttackType = AttackType.Dodge;
            m_Animator.CrossFade($"Dodge{randAnim}", 0.1f);
        }
    }

    private void HandleFastAttack()
    {
        if (m_InputHandler.IsFastAttacking == true)
        {
            ResetTime();
            m_AttackType = AttackType.SwordFast;
            m_Animator.CrossFade($"Fast Attack", 0.1f);
        }
    }

    private void HandleStrongAttack()
    {
        if (IsAttackButtonHeld("Attack") || IsAttackAxisReleased("Strong Attack"))
        {
            m_HoldTime += Time.deltaTime;
            Debug.Log($"m_HoldTime = {m_HoldTime}");
            PlayerMovement.PauseControls();
            if(m_HoldTime >= MIN_HOLD_TIME)
            {
                m_HoldTime = 0;
                ResetTime();
                m_AttackType = AttackType.SwordFast;
                m_Animator.CrossFade($"Strong Attack", 0.1f);
            }
        }
    }

    private bool IsAttackButtonReleased(string controlName)
    {
        /*if (Input.GetButtonUp(controlName) && m_AttackType == AttackType.None)
        {
            return true;
        }*/
        return false;
    }

    private bool IsAttackButtonHeld(string controlName)
    {
        /*if (Input.GetButton(controlName) && m_AttackType == AttackType.None)
        {
            return true;
        }*/
        return false;
    }

    private bool IsAttackAxisReleased(string controlName)
    {
        /*if (Gamepad.current.rightTrigger.isPressed == rtPressedLastFrame && m_AttackType == AttackType.None)
        {
            return true;
        }*/
        return false;
    }
}
