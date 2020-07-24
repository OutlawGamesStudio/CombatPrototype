using System;
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

    private static Combat Instance;

    [SerializeField] private AttackType m_AttackType = AttackType.None;
    [SerializeField] private float m_HoldTime = 0f;
    private InputHandler m_InputHandler;
    private float m_StrongAttackBeingPerformed;
    private NPC m_LockOnTarget;
    private float m_LockOnPerformed;
    public bool WeaponSheathed { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else Destroy(gameObject);
    }

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
        HandleWeaponSheath();
        if (Player.Instance.CharacterStats.InCombat == true)
        {
            HandleLockOn();
            HandleDodge();
            HandleFastAttack();
            HandleStrongAttack();
        }
        if(m_StrongAttackBeingPerformed > 0)
        {
            m_StrongAttackBeingPerformed -= Time.deltaTime;
        }
        if(m_LockOnPerformed > 0)
        {
            m_LockOnPerformed -= Time.deltaTime;
        }
    }

    private void HandleWeaponSheath()
    {
        if (m_LockOnPerformed > 0)
        {
            return;
        }
        if(m_InputHandler.GetSheath())
        {
            Player.Instance.CharacterStats.InCombat = !Player.Instance.CharacterStats.InCombat;
            if(Player.Instance.CharacterStats.InCombat)
            {
                m_Animator.CrossFade("Combat Withdraw Sword", 0.1f);
            }
            else
            {
                m_Animator.CrossFade("Combat Sheath Sword", 0.1f);
            }
            m_LockOnPerformed = 0.25f;
        }
    }

    private void HandleLockOn()
    {
        if (m_LockOnPerformed > 0)
        {
            return;
        }
        if (m_LockOnTarget != null && m_LockOnTarget.CharacterStats.IsDead == true)
        {
            CameraController.Instance.LockOn(null);
        }
        if(m_InputHandler.GetLockOn())
        {
            if(m_LockOnTarget != null)
            {
                m_LockOnTarget = null;
                CameraController.Instance.LockOff();
                m_LockOnPerformed = 0.25f;
                return;
            }

            NPC[] npcs = GameObject.FindObjectsOfType<NPC>();
            float distance = 10f;
            NPC closestNPC = null;
            foreach(var npc in npcs)
            {
                float dist = Vector3.Distance(npc.transform.position, transform.position);
                if (dist < distance && npc.CharacterStats.IsDead == false)
                {
                    distance = dist;
                    closestNPC = npc;
                }
            }
            if (closestNPC != null && m_LockOnTarget != closestNPC)
            {
                Debug.Log($"LockOn to {closestNPC}");
                CameraController.Instance.LockOn(closestNPC);
            }
        
            m_LockOnTarget = closestNPC;
            m_LockOnPerformed = 0.25f;
        }

    }

    private void HandleDodge()
    {
        if (m_InputHandler.GetDodge())
        {
            ResetTime();
            int randAnim = UnityEngine.Random.Range(1, 3);
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
            MeleeWeapon.AttackAllowed = true;
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
        if (m_HoldTime > 0 && m_HoldTime >= MIN_HOLD_TIME && !(m_StrongAttackBeingPerformed > 0))
        {
            PlayerMovement.PauseControls(1);
            ResetTime();
            MeleeWeapon.AttackAllowed = true;
            m_AttackType = AttackType.SwordStrong;
            m_Animator.CrossFade($"Strong Attack", 0.1f);
            m_StrongAttackBeingPerformed = 0.5f;
        }
    }

    public static bool GetCombat()
    {
        return !Instance.WeaponSheathed;
    }
}
