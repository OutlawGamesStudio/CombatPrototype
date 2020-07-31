using UnityEngine;

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

    [Range(0f, 1f)] public float statePriority;
    public bool shouldRepeat = false;
    public bool shouldReturnToPreviousState = false;

    protected StateMachine m_StateMachine;

    public virtual bool EnterState(StateMachine stateMachine, float deltaTime)
    {
        m_StateMachine = stateMachine;
        ExecutionState = ExecutionState.Active;
        return true;
    }

    public virtual bool TerminateState()
    {
        ExecutionState = ExecutionState.Terminated;
        return true;
    }

    public virtual bool CompleteState()
    {
        ExecutionState = ExecutionState.Completed;
        return true;
    }

    public abstract void Execute(float deltaTime);
}