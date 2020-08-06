using ForgottenLegends.Character;
using ForgottenLegends.Data;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;

namespace ForgottenLegends.AI
{
    [RequireComponent(typeof(NavMeshAgent), typeof(NPC))]
    public class StateMachine : MonoBehaviour
    {
        #region Variables
        private NavMeshAgent m_NavMeshAgent = null;
        [SerializeField] private AiState m_PreviousState = null;
        public AiState CurrentState;
        private AiState m_BackupState = null;
        private NPC m_NPC = null;
        #endregion

        private void Start()
        {
            m_NavMeshAgent = GetComponent<NavMeshAgent>();
            m_NavMeshAgent.autoBraking = true;
            m_NPC = GetComponent<NPC>();
            m_BackupState = GetActorStateByName<AiWait>("IdleState.json");
        }

        private T GetActorStateByName<T>(string stateName) where T : AiState
        {
            string actorRoot = $"{Application.streamingAssetsPath}/Data/Ai";
            if (!Directory.Exists(actorRoot))
            {
                throw new System.Exception($"Directory {actorRoot} does not exist.");
            }
            T aiState = AiLoader.Load<T>($"{actorRoot}/{stateName}");
            if (aiState == null)
            {
                throw new System.Exception($"Cannot find actor state {stateName} in {actorRoot} as file does not exist or is not readable.");
            }
            return aiState;
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
                if(m_NPC.ActorInfo.ActorState == null)
                {
                    return;
                }

                if(m_NPC.ActorInfo.ActorState.ActorState != null && m_NPC.ActorInfo.ActorState.ActorStateType > StateType.None)
                {
                    switch(m_NPC.ActorInfo.ActorState.ActorStateType)
                    {
                        case StateType.Combat:
                            SetCurrentState(GetActorStateByName<AiCombat>(m_NPC.ActorInfo.ActorState.ActorState));
                            break;
                        case StateType.Patrol:
                            SetCurrentState(GetActorStateByName<AiPatrol>(m_NPC.ActorInfo.ActorState.ActorState));
                            break;
                        case StateType.Travel:
                            SetCurrentState(GetActorStateByName<AiTravel>(m_NPC.ActorInfo.ActorState.ActorState));
                            break;
                        case StateType.Wait:
                            SetCurrentState(GetActorStateByName<AiWait>(m_NPC.ActorInfo.ActorState.ActorState));
                            break;
                        case StateType.Wander:
                            SetCurrentState(GetActorStateByName<AiWander>(m_NPC.ActorInfo.ActorState.ActorState));
                            break;
                        default:
                            throw new System.Exception($"ActorStateType ({(int)m_NPC.ActorInfo.ActorState.ActorStateType}) invalid.");
                            break;
                    }
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
                    UnityEngine.Debug.Log($"Setting CurrentState to previous state: {CurrentState.Name}");
                }
                return;
            }
            CurrentState.Execute(Time.deltaTime);
        }

        private bool ShouldReturnToPreviousState()
        {
            if (CurrentState.ShouldReturnToPreviousState == true)
            {
                return true;
            }
            return false;
        }

        public void SetCurrentState(AiState aiState)
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