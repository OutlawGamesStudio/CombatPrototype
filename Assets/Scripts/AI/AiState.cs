using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public enum ExecutionState
{
    None,
    Active,
    Completed,
    Terminated
};

public abstract class AiState : ScriptableObject
{
    public ExecutionState ExecutionState { get; protected set; }
    protected StateMachine m_StateMachine;


    public virtual void OnEnable()
    {
        ExecutionState = ExecutionState.None;
    }

    public virtual bool EnterState(StateMachine stateMachine)
    {
        ExecutionState = ExecutionState.Active;
        m_StateMachine = stateMachine;
        return true;
    }

    public abstract void Execute(NPC npc);

    public virtual bool ExitState()
    {
        ExecutionState = ExecutionState.Completed;
        m_StateMachine.ExitState();
        return true;
    }

    protected bool PathTo(Vector3 destination)
    {
        m_StateMachine.SetDestination(destination);
        Vector3 position = m_StateMachine.transform.position;
        float destinationTolerance = 1f;

        float distance = Vector3.Distance(position, destination);
        bool destinationReached = distance <= destinationTolerance;

        if(!destinationReached)
        {
            
        }
        return false;
    }
}
