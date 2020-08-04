using ForgottenLegends.Animation;
using ForgottenLegends.Character;
using UnityEngine;

public class PlayerMovement : CharacterAnimator
{
    private static PlayerMovement Instance;
    private const int SPEED_MULT = 4;

    [SerializeField] private float m_Speed = 0f;
    [SerializeField] private bool m_IsRunning = false;
    [SerializeField] private float m_Limit = MOVE_LIMIT/2;
    private InputHandler m_InputHandler;
    public bool InCombat;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else Destroy(gameObject);
    }

    protected override void Start()
    {
        base.Start();
        m_InputHandler = InputHandler.Instance;
    }

    // Update is called once per frame
    protected override void Update()
    {
        HandleInput();
        base.Update();
    }

    private void HandleInput()
    {
        GetInput();
        ProcessInputData();
    }

    private void ProcessInputData()
    {
        if (!m_IsRunning)
        {
            if (m_Limit > MOVE_LIMIT / 2)
            {
                m_Limit -= Time.deltaTime * 2;
                ResetMovementLimitToHalf();
            }
        }
        else
        {
            if (m_Limit >= MOVE_LIMIT / 2 && m_Limit < MOVE_LIMIT)
            {
                m_Limit += Time.deltaTime * 2;
            }
        }
        ClampMovementData();
    }

    private void ClampMovementData()
    {
        float x = Mathf.Clamp(CharacterMovementVelocity.x, -m_Limit, m_Limit);
        float y = Mathf.Clamp(CharacterMovementVelocity.y, -MOVE_LIMIT, m_Limit);
        SetMovementVelocity(x, y);
    }

    private void ResetMovementLimitToHalf()
    {
        if (m_Limit < MOVE_LIMIT / 2)
        {
            m_Limit = 0.5f;
        }
    }

    private void GetInput()
    {
        m_InputHandler.TickInput(Time.deltaTime);
        m_IsRunning = m_InputHandler.IsRunning;
        SetMovementVelocity(m_InputHandler.Horizontal, m_InputHandler.Vertical);
    }

    protected override void UpdateMovement()
    {
        m_Animator.SetBool("InCombat", Player.Instance.ActorData.CharacterStats.InCombat);
        if (CharacterMovementVelocity.x != 0.0f || CharacterMovementVelocity.y != 0.0f)
        {
            var camRot = CameraController.Instance.transform.eulerAngles.y;

            Vector3 playerMovement = new Vector3(CharacterMovementVelocity.x, 0, CharacterMovementVelocity.y) * m_Speed * Time.deltaTime;
            transform.Translate(playerMovement, Space.Self);

            var newRotation = Quaternion.Euler(0, camRot, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * (m_Speed * SPEED_MULT));
        }
        base.UpdateMovement();
    }

    public static void PauseControls(float time = 0.5f)
    {
        Instance.SetPauseMovement(time);
    }
}
