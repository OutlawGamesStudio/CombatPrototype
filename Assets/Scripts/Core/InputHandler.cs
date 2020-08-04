using UnityEngine;
using UnityEngine.InputSystem;

namespace ForgottenLegends.Core
{
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
        private float m_AttackHold;
        public float m_ShieldHold;

        private void OnEnable()
        {
            if (InputActions == null)
            {
                InputActions = new InputActions();
                InputActions.Movement.Movement.performed += InputActions => MovementInput = InputActions.ReadValue<Vector2>();
                InputActions.Movement.Camera.performed += i => CameraInput = i.ReadValue<Vector2>();
                InputActions.Movement.CameraScroll.performed += camScroll => m_MouseScrollInternal = camScroll.ReadValue<Vector2>();
                InputActions.Movement.Running.performed += runPerform => IsRunning = true;
                InputActions.Movement.Running.canceled += runCancel => IsRunning = false;
                InputActions.Attack.FastAttack.started += _ => { m_AttackHold += Time.deltaTime; };
                InputActions.Attack.FastAttack.canceled += _ => { m_AttackHold = 0; };
                InputActions.Attack.Shield.started += _ => { m_ShieldHold += Time.deltaTime; };
                InputActions.Attack.Shield.canceled += _ => { m_ShieldHold = 0; };
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
            return InputActions.Attack.Sheath.ReadValue<float>() > 0;
        }

        public bool GetAttackDown()
        {
            return m_AttackHold > 0;
        }

        public float GetAttackHoldTime() => m_AttackHold;

        public bool GetAttackUp()
        {
            return m_AttackHold == 0;
        }

        public bool GetShieldDown()
        {
            return m_ShieldHold > 0;
        }

        public float GetShieldHoldTime() => m_ShieldHold;

        public bool GetShieldUp()
        {
            return m_ShieldHold == 0;
        }

        public bool GetDodge()
        {
            return InputActions.Attack.Dodge.ReadValue<float>() > 0;
        }

        public bool GetLockOn()
        {
            return InputActions.Attack.LockOn.ReadValue<float>() > 0;
        }

        public bool GetMagic()
        {
            return InputActions.Attack.CastSpell.ReadValue<float>() > 0;
        }

        public bool GetActivate()
        {
            return InputActions.Interface.Activate.ReadValue<float>() > 0;
        }
    }
}