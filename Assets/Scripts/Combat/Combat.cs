using System;
using UnityEngine;
using Random = UnityEngine.Random;

public enum WeaponType
{
    Fists,
    Sword,
    Bow,
    Spear
};

public enum AttackType
{
    None,
    Dodge,
    Fast,
    Strong
};

public class Combat : AnimationScript
{
    private const float MIN_HOLD_TIME = 1f;

    private static Combat Instance;

    [SerializeField] private AttackType m_AttackType = AttackType.None;
    [SerializeField] private float m_HoldTime = 0f;
    private float m_BlockTime = 0f;
    private InputHandler m_InputHandler;
    private float m_StrongAttackBeingPerformed;
    private NPC m_LockOnTarget;
    private float m_LockOnPerformed;
    private AudioSource m_AudioSource;
    private AudioClip Unsheath;
    private AudioClip Sheath;
    [SerializeField] private AudioSource SwingAudioSource;
    [SerializeField] private float audioDelay = 0.1f;
    [SerializeField] private WeaponType m_WeaponType;
    [SerializeField] private float m_BlockedRecently;

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
        m_AudioSource = gameObject.AddComponent<AudioSource>();
        m_AudioSource.loop = false;
        Unsheath = Resources.Load<AudioClip>("Audio/SFX/Unsheath");
        Sheath = Resources.Load<AudioClip>("Audio/SFX/Sheath");
        m_BlockedRecently = 0;
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
            HandleBlock();
            HandleBowFire();
        }
        if(m_StrongAttackBeingPerformed > 0)
        {
            m_StrongAttackBeingPerformed -= Time.deltaTime;
        }
        if(m_LockOnPerformed > 0)
        {
            m_LockOnPerformed -= Time.deltaTime;
        }
        if(m_BlockedRecently > 0)
        {
            m_BlockedRecently -= Time.deltaTime;
        }
    }

    private void HandleBlock()
    {
        if (m_WeaponType != WeaponType.Sword)
        {
            return;
        }
        if (m_InputHandler.GetShieldDown() && m_BlockTime <= 0)
        {
            m_Animator.SetBool("Blocking", true);
            m_Animator.CrossFade($"Sword Block", 0.1f);
            m_BlockTime += Time.deltaTime;
            Debug.Log("Blocking " + m_BlockTime);
        }
        if (m_InputHandler.GetShieldUp())
        {
            m_Animator.SetBool("Blocking", false);
            m_BlockTime = 0;
        }
    }

    private void HandleBowFire()
    {
        if(m_WeaponType != WeaponType.Bow)
        {
            return;
        }
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
                m_AudioSource.clip = Unsheath;
                m_Animator.CrossFade("Combat Withdraw Sword", 0.1f);
            }
            else
            {
                m_AudioSource.clip = Sheath;
                m_Animator.CrossFade("Combat Sheath Sword", 0.1f);
            }
            m_AudioSource.Play();
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
            DisableLockOn();
        }
        if (m_InputHandler.GetLockOn())
        {
            if(m_LockOnTarget != null)
            {
                m_LockOnTarget = null;
                DisableLockOn();
                m_LockOnPerformed = 0.25f;
                return;
            }

            NPC[] npcs = GameObject.FindObjectsOfType<NPC>();
            float distance = 100f;
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
                if(closestNPC.CharacterStats.IsBoss)
                {
                    BossUI.Instance.AssignBoss(closestNPC);
                }
                else
                {
                    BossUI.Instance.AssignBoss(null);
                }
                CameraController.Instance.LockOn(closestNPC);
            }
        
            m_LockOnTarget = closestNPC;
            m_LockOnPerformed = 0.25f;
        }

    }

    private void DisableLockOn()
    {
        CameraController.Instance.LockOff();
        BossUI.Instance.AssignBoss(null);
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
        if (m_WeaponType != WeaponType.Sword && m_WeaponType != WeaponType.Spear)
        {
            return;
        }
        if(m_BlockedRecently > 0f)
        {
            return;
        }

        if (m_InputHandler.GetAttackDown())
        {
            m_HoldTime += Time.deltaTime;
        }
        if (m_InputHandler.GetAttackUp() && m_HoldTime > 0 && m_HoldTime < MIN_HOLD_TIME)
        {
            int index = Convert.ToInt32(Random.value > 0.5f)+1;
            ResetTime();
            MeleeWeapon.AttackAllowed = true;
            m_AttackType = AttackType.Fast;
            m_Animator.CrossFade($"Fast Attack " + index, 0.1f);
            SwingAudioSource.PlayDelayed(audioDelay);
            m_BlockedRecently = 1f;
        }
    }

    private void HandleStrongAttack()
    {
        if (m_WeaponType != WeaponType.Sword && m_WeaponType != WeaponType.Spear)
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
            m_Animator.CrossFade($"Strong Attack", 0.1f);
            m_StrongAttackBeingPerformed = 1.5f;
            SwingAudioSource.PlayDelayed(audioDelay);
        }
    }

    public static bool GetCombat()
    {
        return !Instance.WeaponSheathed;
    }
}
