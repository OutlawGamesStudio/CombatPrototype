using ForgottenLegends.Character;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ForgottenLegends.AI
{
    [RequireComponent(typeof(NavMeshAgent), typeof(NPC))]
    public class StateMachine : MonoBehaviour
    {
        #region Variables
        private NavMeshAgent m_NavMeshAgent = null;
        [SerializeField] private AiScriptableState m_PreviousState = null;
        public AiScriptableState CurrentState;
        private AiScriptableState m_BackupState = null;
        private NPC m_NPC = null;
        #endregion

        private void Start()
        {
            m_NavMeshAgent = GetComponent<NavMeshAgent>();
            m_NavMeshAgent.autoBraking = true;
            m_NPC = GetComponent<NPC>();
            m_BackupState = Resources.Load<AiScriptableState>("Ai/IdleState");
        }

        private AiScriptableState GetActorStateByName(string stateName)
        {
            return Resources.Load<AiScriptableState>($"Ai/{stateName}");
        }

        private void Update()
        {
            if (m_NPC.ActorInfo.CharacterStats.IsDead == true)
            {
                StopPathing();
                return;
            }

            if (CurrentState == null)
            {
                if(m_NPC.ActorInfo.ActorState != null)
                {
                    SetCurrentState(GetActorStateByName(m_NPC.ActorInfo.ActorState));
                    return;
                }
                SetCurrentState(m_BackupState);
                return;
            }

            if (CurrentState.ExecutionState == ExecutionState.Terminated || CurrentState.ExecutionState == ExecutionState.Completed)
            {
                if (ShouldReturnToPreviousState())
                {
                    SetCurrentState(m_PreviousState);
                    UnityEngine.Debug.Log($"Setting CurrentState to previous state: {CurrentState.name}");
                }
                return;
            }
            CurrentState.Execute(Time.deltaTime);
        }

        private bool ShouldReturnToPreviousState()
        {
            if (CurrentState.shouldReturnToPreviousState == true)
            {
                return true;
            }
            return false;
        }

        public void SetCurrentState(AiScheduleType aiState)
        {
            m_PreviousState = CurrentState;
            CurrentState = aiState.aiState;
            CurrentState.EnterState(this, Time.deltaTime);
        }

        public void SetCurrentState(AiScriptableState aiState)
        {
            m_PreviousState = CurrentState;
            CurrentState = aiState;
            CurrentState.EnterState(this, Time.deltaTime);
        }

        public bool PathTo(Vector3 destination)
        {
            if (m_NavMeshAgent.isStopped)
            {
                m_NavMeshAgent.isStopped = false;
            }

            m_NavMeshAgent.SetDestination(destination);
            return true;
        }

        public void StopPathing()
        {
            m_NavMeshAgent.isStopped = true;
        }

        public void FacePosition(Vector3 position, float damping = 2f)
        {
            var lookPos = position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
        }
    }
}