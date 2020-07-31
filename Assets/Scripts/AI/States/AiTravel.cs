using UnityEngine;

[CreateAssetMenu(fileName = "TravelState", menuName = "AI/States/Travel")]
public class AiTravel : AiState
{
    public Vector3 destination;
    public float destinationTolerance = 1f;

    public override void Execute(float deltaTime)
    {
        float distance = Vector3.Distance(m_StateMachine.transform.position, destination);
        if(distance <= destinationTolerance)
        {
            m_StateMachine.StopPathing();
            CompleteState();
            return;
        }
        m_StateMachine.PathTo(destination);
    }
}
