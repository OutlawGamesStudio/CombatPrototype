﻿using ForgottenLegends.AI;
using ForgottenLegends.Animation;
using ForgottenLegends.Combat;
using UnityEngine;

namespace ForgottenLegends.Character
{
    [RequireComponent(typeof(NPCAnimator), typeof(StateMachine), typeof(NpcCombat))]
    public class NPC : Actor
    {
        private StateMachine m_StateMachine;
        public StateMachine StateMachine => m_StateMachine;

        public NPCAnimator NPCAnimator { get; private set; }
        public NpcCombat NPCCombat { get; private set; }

        protected override void Start()
        {
            m_StateMachine = GetComponent<StateMachine>();
            NPCAnimator = GetComponent<NPCAnimator>();
            NPCCombat = GetComponent<NpcCombat>();
            base.Start();
        }

        protected override void Update()
        {
            if (Vector3.Distance(transform.position, Player.Instance.transform.position) <= 10f)
            {
                if (m_StateMachine.CurrentState == null || m_StateMachine.CurrentState.GetType() != typeof(AiCombat))
                {
                    AiCombat aiCombat = new AiCombat();
                    aiCombat.InitiateCombat(NPCCombat, m_ActorInfo.CharacterStats.CombatStyle, Player.Instance);
                    m_StateMachine.SetCurrentState(aiCombat);
                    return;
                }
            }
        }
    }
}