using System;
using System.Collections.Generic;
using System.Linq;
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
    private Queue<AiScheduleType> m_AiStateQueue = new Queue<AiScheduleType>();

    [SerializeField] private AiSchedule m_AiSchedule = null;
    public List<AiScheduleType> queue = new List<AiScheduleType>(); // debugging only, remove once queuing is working
    #endregion

    private void Start()
    {
        m_NavMeshAgent = GetComponent<NavMeshAgent>();
        m_NavMeshAgent.autoBraking = true;
        m_NPC = GetComponent<NPC>();
        m_BackupState = Resources.Load<AiState>("Ai/IdleState");
        if (m_AiSchedule == null)
        {
            Debug.LogError($"You must assign a schedule to the NPC.");
        }
    }

    private void Update()
    {
        queue = m_AiStateQueue.ToList();
        if (m_NPC.CharacterStats.IsDead == true || m_AiSchedule == null)
        {
            StopPathing();
            return;
        }

        if(m_AiStateQueue.Count < 1)
        {
            foreach(var state in m_AiSchedule.aiSchedule)
            {
                InsertQueue(state);
            }
        }

        if(CurrentState != null && m_PreviousState != null && CurrentState.name == m_PreviousState.name)
        {
            NextState();
            return;
        }

        if (m_AiStateQueue.Count > 0 && CurrentState == null)
        {
            if(m_AiStateQueue.ElementAt(0) != null)
            {
                NextState();
            }
            else
            {
                SetCurrentState(m_BackupState);
            }
            return;
        }
        if (CurrentState.ExecutionState == ExecutionState.Terminated || CurrentState.ExecutionState == ExecutionState.Completed)
        {
            if (CurrentState.shouldRepeat == true)
            {
                AiScheduleType currentState = new AiScheduleType();
                currentState.aiState = CurrentState;
                m_AiStateQueue.Enqueue(currentState);
                Debug.Log($"Adding repeating state {CurrentState.name} to queue.");
            }
            if(CurrentState.shouldReturnToPreviousState == true)
            {
                SetCurrentState(m_PreviousState);
                Debug.Log($"Setting CurrentState to previous state: {CurrentState.name}");
            }
            else
            {
                NextState();
            }
            return;
        }
        CurrentState.Execute(Time.deltaTime);
    }

    private void NextState()
    {
        AiScheduleType aiState = m_AiStateQueue.Dequeue();
        SetCurrentState(aiState);
        Debug.Log($"Dequeueing state {aiState.aiState}");
    }

    public void SetCurrentState(AiScheduleType aiState, bool ignoreRequirements = false)
    {
        if(ignoreRequirements == false && aiState.HasMetCondition() == false)
        {
            return;
        }
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

    public void InsertQueue(AiScheduleType aiState)
    {
        m_AiStateQueue.Enqueue(aiState);
    }
}
