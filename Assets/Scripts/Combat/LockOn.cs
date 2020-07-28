using System;
using UnityEngine;

public class LockOn : CombatScript
{
    public override WeaponType WeaponType => throw new NotImplementedException();
    private NPC m_LockOnTarget;
    private Transform m_Transform;

    public LockOn(Animator animator, Transform transform, Combat combat) : base(animator, combat)
    {
        m_Transform = transform;
    }

    public override void Execute()
    {
        HandleLockOn();
    }

    /// <summary>
    /// Not implemented
    /// </summary>
    public override void OnWeaponSheath()
    {
        throw new NotImplementedException();
    }

    public override void PostExecute()
    {
        if (m_HoldTime > 0)
        {
            m_HoldTime -= Time.deltaTime;
        }
    }

    private void HandleLockOn()
    {
        if (m_HoldTime > 0)
        {
            return;
        }
        if (m_LockOnTarget != null && m_LockOnTarget.CharacterStats.IsDead == true)
        {
            DisableLockOn();
        }
        if (m_InputHandler.GetLockOn())
        {
            if (m_LockOnTarget != null)
            {
                m_LockOnTarget = null;
                DisableLockOn();
                m_HoldTime = 0.25f;
                return;
            }

            NPC[] npcs = GameObject.FindObjectsOfType<NPC>();
            float distance = 100f;
            NPC closestNPC = null;
            foreach (var npc in npcs)
            {
                float dist = Vector3.Distance(npc.transform.position, m_Transform.position);
                if (dist < distance && npc.CharacterStats.IsDead == false)
                {
                    distance = dist;
                    closestNPC = npc;
                }
            }
            if (closestNPC != null && m_LockOnTarget != closestNPC)
            {
                if (closestNPC.CharacterStats.IsBoss)
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
            m_HoldTime = 0.25f;
        }

    }

    private void DisableLockOn()
    {
        CameraController.Instance.LockOff();
        BossUI.Instance.AssignBoss(null);
    }
}
