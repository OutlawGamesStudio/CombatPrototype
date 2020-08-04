using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class AnimationScript : MonoBehaviour
{
    public Animator Animator => m_Animator;
    protected Animator m_Animator;
    protected RuntimeAnimatorController m_RuntimeAnimatorController;

    // There has to be a better way to do this, but it'll do for now.
    // Perhaps have an array of a ScriptableObject type that records the animation and character type?
    [SerializeField] protected CombatAnimation[] m_CombatAnimations = null;

    [SerializeField] protected AnimationClip[] m_DodgeAttacks = null;

    protected virtual void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_RuntimeAnimatorController = m_Animator.runtimeAnimatorController;
    }

    public void AssignActorCombatAnimations(Actor actor)
    {
        string folderName = $"Combat/{actor.ActorData.CharacterStats.AnimationType}";
        Debug.Log("Loading actor combat animations from " + folderName);
        m_CombatAnimations = Resources.LoadAll<CombatAnimation>(folderName);
    }

    protected void PlayAnimation(string animation)
    {
        m_Animator.CrossFade(animation, .1f);
    }

    public void PlayFastAttack(WeaponType weaponType)
    {
        foreach(var combatAnimation in m_CombatAnimations)
        {
            if(combatAnimation.WeaponType == weaponType)
            {
                // Add 1 to the array length as Random.Range is exclusive at the max number.
                int index = Random.Range(0, combatAnimation.FastAttack.Length);
                PlayAnimation(combatAnimation.FastAttack[index].name);
                break;
            }
        }
    }

    public void PlayStrongAttack(WeaponType weaponType)
    {
        foreach (var combatAnimation in m_CombatAnimations)
        {
            if (combatAnimation.WeaponType == weaponType)
            {
                // Add 1 to the array length as Random.Range is exclusive at the max number.
                int index = Random.Range(0, combatAnimation.StrongAttack.Length);
                PlayAnimation(combatAnimation.StrongAttack[index].name);
                break;
            }
        }
    }

    public void PlayDodge()
    {
        int index = Random.Range(0, m_DodgeAttacks.Length);
        PlayAnimation(m_DodgeAttacks[index].name);
    }
}