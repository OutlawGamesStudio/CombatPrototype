using ForgottenLegends.Core;
using UnityEngine;

namespace ForgottenLegends.Combat
{
    public abstract class CombatScript
    {
        public abstract WeaponType WeaponType { get; }
        protected InputHandler m_InputHandler;
        protected AttackType m_AttackType;
        protected Animator m_Animator;
        protected AudioClip m_Unsheath;
        protected AudioClip m_Sheath;
        protected float m_HoldTime;
        protected AnimationScript m_CombatHandler;

        protected CombatScript(Animator animator, AnimationScript combatHandler)
        {
            m_CombatHandler = combatHandler;
            m_InputHandler = InputHandler.Instance;
            m_Animator = animator;
            ResetTime();
        }

        protected void ResetTime()
        {
            m_HoldTime = 0;
        }

        public abstract void OnWeaponSheath();
        public abstract void Execute();
        public abstract void PostExecute();
    }
}