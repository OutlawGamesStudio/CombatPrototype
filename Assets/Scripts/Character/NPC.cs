using UnityEngine;

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
        if(CharacterStats.Level < 1)
        {
            CharacterStats.Level = 1;
        }
        if(CharacterStats.IsBoss)
        {
            CharacterStats.MaxHealth = 200 * CharacterStats.Level;
        }
        else
        {
            CharacterStats.MaxHealth = 100 * CharacterStats.Level;
        }
        CharacterStats.CurrentHealth = CharacterStats.MaxHealth;
    }

    private void Update()
    {
        CharacterStats.Position = transform.position;
        CharacterStats.Rotation = transform.rotation;
        if(Vector3.Distance(transform.position, Player.Instance.transform.position) <= 10f)
        {

        }
    }

    public void OnWeaponDamage(float damage)
    {
        Debug.Log($"NPC {name} has been attacked with a damage modifier of {damage}");
        CharacterStats.CurrentHealth -= damage;
        if(CharacterStats.CurrentHealth <= 0)
        {
            Debug.Log($"NPC {name} is now dead.");
            CharacterStats.IsDead = true;
            NPCAnimator.DeathAnimation();
        }
    }
}