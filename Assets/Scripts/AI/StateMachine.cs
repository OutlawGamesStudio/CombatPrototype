using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
        m_BackupState = Resources.Load<AiState>("Ai/IdleState");
    }

    private void Update()
    {
        if (m_NPC.ActorData.CharacterStats.IsDead == true)
        {
            StopPathing();
            return;
        }

        if (CurrentState == null)
        {
            SetCurrentState(m_BackupState);
            return;
        }

        if (CurrentState.ExecutionState == ExecutionState.Terminated || CurrentState.ExecutionState == ExecutionState.Completed)
        {
            if (ShouldReturnToPreviousState())
            {
                SetCurrentState(m_PreviousState);
                Debug.Log($"Setting CurrentState to previous state: {CurrentState.name}");
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

    public void SetCurrentState(AiState aiState)
    {
        m_PreviousState = CurrentState;
        CurrentState = aiState;
        CurrentState.EnterState(this, Time.deltaTime);
    }

    public bool PathTo(Vector3 destination)
    {
        if(m_NavMeshAgent.isStopped)
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
