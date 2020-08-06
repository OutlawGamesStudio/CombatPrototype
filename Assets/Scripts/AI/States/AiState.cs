using System;

namespace ForgottenLegends.AI
{
    [Serializable]
    public abstract class AiState
    {
        [NonSerialized] public ExecutionState ExecutionState;
        [NonSerialized] protected StateMachine m_StateMachine;

        public string Name;
        public float StatePriority;
        public bool ShouldRepeat;
        public bool ShouldReturnToPreviousState;

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
}
