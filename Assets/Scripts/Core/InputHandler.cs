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

    public bool IsFastAttacking { get; private set; }
    public bool IsStrongAttacking { get; private set; }
    public bool RollForward { get; private set; }

    // Private Variables
    private Vector2 m_MouseScrollInternal;
    private float m_HoldTime;

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
            InputActions.Attack.FastAttack.started += _ => { m_HoldTime += Time.deltaTime; Debug.Log($"Fast attack performed {m_HoldTime}"); };
            InputActions.Attack.FastAttack.canceled += _ => { m_HoldTime = 0; Debug.Log("Fast attack canceled"); };
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

    public bool GetSheath()
    {
        Debug.Log($"GetSheath: {InputActions.Attack.Sheath.ReadValue<float>() > 0}");
        return InputActions.Attack.Sheath.ReadValue<float>() > 0;
    }

    public bool GetAttackDown()
    {
        return m_HoldTime > 0;
    }

    public float GetAttackHoldTime() => m_HoldTime;

    public bool GetAttackUp()
    {
        return m_HoldTime == 0;
    }

    public bool GetDodge()
    {
        Debug.Log($"InputActions.Attack.Dodge: {InputActions.Attack.Dodge.ReadValue<float>() > 0}");
        return InputActions.Attack.Dodge.ReadValue<float>() > 0;
    }

    public bool GetLockOn()
    {
        Debug.Log($"LockOn: {InputActions.Attack.LockOn.ReadValue<float>() > 0}");
        return InputActions.Attack.LockOn.ReadValue<float>() > 0;
    }
}
