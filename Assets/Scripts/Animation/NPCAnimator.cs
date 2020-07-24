using System;
using UnityEngine;

public class NPCAnimator : CharacterAnimator
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public void DeathAnimation()
    {
        m_Animator.CrossFade("Death", 0.1f);
    }
}
