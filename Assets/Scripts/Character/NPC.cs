using UnityEngine;

[RequireComponent(typeof(NPCAnimator), typeof(StateMachine))]
public class NPC : Actor
{
    [SerializeField] private StateMachine m_StateMachine;
    public StateMachine StateMachine => m_StateMachine;

    public NPCAnimator NPCAnimator { get; private set; }

    protected override void Start()
    {
        m_StateMachine = GetComponent<StateMachine>();
        NPCAnimator = GetComponent<NPCAnimator>();
        base.Start();
    }

    protected override void Update()
    {
        if(Vector3.Distance(transform.position, Player.Instance.transform.position) <= 10f)
        {

        }
    }
}