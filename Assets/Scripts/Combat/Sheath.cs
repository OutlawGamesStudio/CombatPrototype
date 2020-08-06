using ForgottenLegends.Character;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ForgottenLegends.Combat
{
    public class Sheath : CombatScript
    {
        public override WeaponType WeaponType => throw new NotImplementedException();
        public bool IsSheathed { get; private set; }
        public List<CombatScript> m_CombatScripts;
        private AudioSource m_AudioSource;

        public Sheath(Animator animator, List<CombatScript> combatScripts, AudioSource audioSource, Combat combat) : base(animator, combat)
        {
            m_CombatScripts = combatScripts;
            m_AudioSource = audioSource;
        }

        public override void Execute()
        {
            HandleWeaponSheath();
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
            m_HoldTime -= Time.deltaTime;
        }

        private void HandleWeaponSheath()
        {
            if (m_HoldTime > 0)
            {
                return;
            }
            if (m_InputHandler.GetSheath())
            {
                Player.Instance.ActorInfo.CharacterStats.InCombat = !Player.Instance.ActorInfo.CharacterStats.InCombat;
                foreach (var combatScript in m_CombatScripts)
                {
                    combatScript.OnWeaponSheath();
                }
                m_AudioSource.Play();
                m_HoldTime = 0.25f;
            }
        }
    }
}