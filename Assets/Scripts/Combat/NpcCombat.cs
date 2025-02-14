﻿using ForgottenLegends.Character;
using ForgottenLegends.Utility;
using System.Collections.Generic;
using UnityEngine;

namespace ForgottenLegends.Combat
{
    public class NpcCombat : AnimationScript
    {
        private AudioSource SwingAudioSource = null;
        private NPC m_NPC;
        private List<CombatScript> m_CombatScripts = new List<CombatScript>();

        protected override void Start()
        {
            base.Start();
            m_NPC = GetComponent<NPC>();
            SwingAudioSource = gameObject.AddComponent<AudioSource>();
            SwingAudioSource.loop = false;
            SwingAudioSource.playOnAwake = false;
            if (m_NPC.ActorInfo.CharacterStats.CombatStyle == WeaponType.Sword)
            {
                SwordCombat swordCombat = new SwordCombat(m_Animator, SwingAudioSource, this);
                m_CombatScripts.Add(swordCombat);
            }
        }

        public void StartAttack(WeaponType weaponType)
        {
            foreach (var combatScript in m_CombatScripts)
            {
                UnityEngine.Debug.Log($"{combatScript.WeaponType} == {weaponType}: {combatScript.WeaponType == weaponType}");
                if (combatScript.WeaponType == weaponType)
                {
                    UnityEngine.Debug.Log($"Executing attack with {weaponType}");
                    combatScript.Execute();
                    combatScript.PostExecute();
                    break;
                }
            }
        }
    }
}