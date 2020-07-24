using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(NPC))]
public class StateMachine : MonoBehaviour
{
    [SerializeField] private AiState m_StartingState;
    [SerializeField] private AiState m_CurrentState;
    [SerializeField] private AiState m_LastState;
    public NavMeshAgent NavMeshAgent { get; private set; }
    public NPC NPC { get; private set; }

    private Queue<AiState> StateQueue = new Queue<AiState>();

    public AiState CurrentState => m_CurrentState;
    public AiState PreviousState => m_LastState;

    private void Awake()
    {
        m_CurrentState = null;
    }

    private void Start()
    {
        NavMeshAgent = GetComponent<NavMeshAgent>();
        NPC = GetComponent<NPC>();
        if (m_StartingState != null)
        {
            EnterState(m_StartingState);
        }
    }

    private void Update()
    {
        if(NPC.CharacterStats.IsDead == true)
        {
            // Do not update if dead.
            Stop();
            if(m_CurrentState != null)
            {
                m_CurrentState.ExitState();
            }
            m_CurrentState = null;
            return;
        }
        if(StateQueue.Count > 0 && m_CurrentState == null)
        {
            NextState();
            return;
        }
        if (m_CurrentState != null)
        {
            m_CurrentState.Execute(NPC);
        }
    }

    public void SetDestination(Vector3 position)
    {
        NavMeshAgent.isStopped = false;
        NavMeshAgent.SetDestination(position);
    }

    public void Stop()
    {
        NavMeshAgent.isStopped = true;
    }

    public void NextState()
    {
        EnterState(StateQueue.Dequeue());
    }

    public void EnterState(AiState nextState)
    {
        m_LastState = m_CurrentState;
        m_CurrentState = nextState;
        m_CurrentState.EnterState(this);
    }

    public void ExitState()
    {
        m_CurrentState = null;
    }

    public void InsertState(AiState state)
    {
        StateQueue.Enqueue(state);
    }
}
