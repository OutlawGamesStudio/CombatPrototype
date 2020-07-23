using System;
using UnityEngine;
using UnityEngine.InputSystem;

public enum AxisName
{
    None,
    RightTrigger
};

public class InputHandler : Singleton<InputHandler>
{
    // Properties
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }
    public float MouseX { get; private set; }
    public float MouseY { get; private set; }
    public float MouseScroll { get; private set; }
    public float MoveAmount { get; private set; }
    public InputActions InputActions { get; private set; }
    public InputActionAsset inputActions { get; private set; }
    public Vector2 MovementInput { get; private set; }
    public Vector2 CameraInput { get; private set; }
    public bool IsRunning { get; private set; }

    private float waitTime = 0;
    public bool IsFastAttacking { get; private set; }
    public bool IsStrongAttacking { get; private set; }

    // Private Variables
    private Vector2 m_MouseScrollInternal;

    private void OnEnable()
    {
        if(InputActions == null)
        {
            InputActions = new InputActions();
            InputActions.Movement.Movement.performed += InputActions => MovementInput = InputActions.ReadValue<Vector2>();
            InputActions.Movement.Camera.performed += i => CameraInput = i.ReadValue<Vector2>();
            InputActions.Movement.CameraScroll.performed += camScroll => m_MouseScrollInternal = camScroll.ReadValue<Vector2>();
            InputActions.Movement.Running.performed += runPerform => IsRunning = true;
            InputActions.Movement.Running.canceled += runCancel => IsRunning = false;
            InputActions.Attack.FastAttack.performed += fstAttck => IsFastAttacking = true;
            InputActions.Attack.FastAttack.canceled += fstAttck => IsFastAttacking = false;
            InputActions.Attack.StrongAttack.performed += strngAttck => IsStrongAttacking = true;
            InputActions.Attack.StrongAttack.canceled += strngAttck => IsStrongAttacking = false;
        }
        InputActions.Enable();
    }

    private void OnDisable()
    {
        InputActions.Disable();
    }

    public void TickInput(float deltaTime)
    {
        MoveInput(deltaTime);
        IsFastAttacking = false;
    }

    private void MoveInput(float deltaTime)
    {
        Horizontal = MovementInput.x;
        Vertical = MovementInput.y;
        MoveAmount = Mathf.Clamp01(Mathf.Abs(Horizontal) + Mathf.Abs(Vertical));
        MouseX = CameraInput.x;
        MouseY = CameraInput.y;
        MouseScroll = m_MouseScrollInternal.y * 20 * deltaTime;
    }
}
