using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NPCAnimator), typeof(StateMachine))]
public class NPC : MonoBehaviour
{
    [SerializeField] private StateMachine m_StateMachine;
    public StateMachine StateMachine => m_StateMachine;

    public CharacterStats CharacterStats;

    public NPCAnimator NPCAnimator { get; private set; }

    private void Start()
    {
        m_StateMachine = GetComponent<StateMachine>();
        NPCAnimator = GetComponent<NPCAnimator>();
    }

    private void Update()
    {
        CharacterStats.Position = transform.position;
        CharacterStats.Rotation = transform.rotation;
        if(Vector3.Distance(transform.position, Player.Instance.transform.position) <= 10f)
        {

        }
    }
}