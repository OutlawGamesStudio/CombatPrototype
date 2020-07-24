using UnityEngine;

public class CharacterAnimator : AnimationScript
{
    protected const float MOVE_LIMIT = 1f;

    public float PauseMovement { get; private set; }
    public Vector2 CharacterMovementVelocity { get; protected set; } = new Vector2();

    [SerializeField] private Animation[] m_FastAttacks;
    [SerializeField] private Animation[] m_StrongAttacks;
    [SerializeField] private Animation[] m_DodgeAttacks;

    protected override void Start()
    {
        base.Start();
    }

    protected virtual void Update()
    {
        HandleMovement();
        HandleMovementPause();
    }

    protected void SetPauseMovement(float time)
    {
        PauseMovement = time;
    }

    protected virtual void HandleMovement()
    {
        // If PauseMovement time is above 0, then skip this method.
        if (PauseMovement > 0)
        {
            return;
        }

        UpdateVelocityX();
        UpdateVelocityY();
        UpdateMovement();
    }

    private void HandleMovementPause()
    {
        if (PauseMovement > 0)
        {
            m_Animator.SetFloat("VelocityX", 0.0f);
            m_Animator.SetFloat("VelocityY", 0.0f);
            PauseMovement -= Time.deltaTime;
            if (PauseMovement < 0)
            {
                PauseMovement = 0;
            }
        }
    }

    public void SetMovementVelocity(float movementVelocityX, float movementVelocityY)
    {
        Vector2 movementVelocity = new Vector2(movementVelocityX, movementVelocityY);
        SetMovementVelocity(movementVelocity);
    }

    public void SetMovementVelocity(Vector2 movementVelocity)
    {
        CharacterMovementVelocity = movementVelocity;
    }

    protected virtual void UpdateMovement()
    {
        if (CharacterMovementVelocity.x != 0.0f || CharacterMovementVelocity.y != 0.0f)
        {
            m_Animator.SetBool("Moving", true);
        }
        else m_Animator.SetBool("Moving", false);
    }

    private void UpdateVelocityX()
    {
        float velX = m_Animator.GetFloat("VelocityX");
        if (CharacterMovementVelocity.x > velX)
        {
            velX += Time.deltaTime;
            if (velX > CharacterMovementVelocity.x)
            {
                velX = CharacterMovementVelocity.x;
            }
            m_Animator.SetFloat("VelocityX", velX);
        }

        if (CharacterMovementVelocity.x < velX)
        {
            velX -= Time.deltaTime;
            if (velX < CharacterMovementVelocity.x)
            {
                velX = CharacterMovementVelocity.x;
            }
            m_Animator.SetFloat("VelocityX", velX);
        }
    }

    private void UpdateVelocityY()
    {
        float velY = m_Animator.GetFloat("VelocityY");
        if (CharacterMovementVelocity.y > velY)
        {
            velY += Time.deltaTime;
            if (velY > CharacterMovementVelocity.y)
            {
                velY = CharacterMovementVelocity.y;
            }
            m_Animator.SetFloat("VelocityY", velY);
        }

        if (CharacterMovementVelocity.y < velY)
        {
            velY -= Time.deltaTime;
            if (velY < CharacterMovementVelocity.y)
            {
                velY = CharacterMovementVelocity.y;
            }
            m_Animator.SetFloat("VelocityY", velY);
        }
    }

    public void PlayAnimation(string animation, bool pause = false)
    {
        if(pause)
        {
            SetPauseMovement(0.5f);
        }
        m_Animator.CrossFade(animation, .1f);
    }

    public void AttackAnimation(bool strong = false)
    {
        int randIndex = Random.Range(0, strong == false ? m_FastAttacks.Length : m_StrongAttacks.Length);
        PlayAnimation(strong == false ? m_FastAttacks[randIndex].name : m_StrongAttacks[randIndex].name, strong == false ? false : true);
    }
}