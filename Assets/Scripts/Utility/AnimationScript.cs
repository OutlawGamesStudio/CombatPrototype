using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class AnimationScript : MonoBehaviour
{
    public Animator Animator => m_Animator;
    protected Animator m_Animator;
    protected RuntimeAnimatorController m_RuntimeAnimatorController;

    protected virtual void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_RuntimeAnimatorController = m_Animator.runtimeAnimatorController;
    }
}