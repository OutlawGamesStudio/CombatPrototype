// GENERATED AUTOMATICALLY FROM 'Assets/Resources/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Attack"",
            ""id"": ""b9331ef6-83d1-428f-9243-7f87d7dc92e2"",
            ""actions"": [
                {
                    ""name"": ""Strong Attack"",
                    ""type"": ""Button"",
                    ""id"": ""3fe5394f-2b33-495e-9b29-e6353ca487f6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""Fast Attack"",
                    ""type"": ""Button"",
                    ""id"": ""83dad013-32c0-4bb2-b29f-cb956a8e9b79"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Dodge"",
                    ""type"": ""Button"",
                    ""id"": ""b2b09c00-737f-45cd-b465-24ec7398a393"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Shield"",
                    ""type"": ""Button"",
                    ""id"": ""e4466319-75ea-46c4-86f4-d7dadce8b9de"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""Cast Spell"",
                    ""type"": ""Button"",
                    ""id"": ""7cc7ddb9-2b91-4c45-a5a7-64bc59190a2a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""bb5daf26-8322-4ef2-9d30-33d5c6a88cb3"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Strong Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ff5af0d9-9881-4348-8043-549cd0ea361f"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Strong Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f43be2be-593c-4b40-a3c2-0373c3f74048"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fast Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ab9d0e58-f61e-4fcb-aede-57e4aa8d29b0"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fast Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3f28d906-6bb5-48df-b30f-9f80313d1b7d"",
                    ""path"": ""<Keyboard>/alt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""26c9d2c5-9299-455a-9da6-6de7fdc55868"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e030eb89-e9d1-4e57-a932-cf783e492e0b"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shield"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dfc68a1f-6e73-487b-9f22-9bda0e57c582"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shield"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""70a312b8-14e3-4197-ba24-25325aa7b7ce"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cast Spell"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f3bb4020-b603-47d0-b4f5-54f557a1456a"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cast Spell"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Movement"",
            ""id"": ""11c48cdb-6dac-440c-bbe2-f8822a325245"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""0691eb0b-d999-42cc-84ac-ee994e1ba42e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Camera"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a96d7e81-1a52-4870-b4ea-3f0979f0e0dd"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraScroll"",
                    ""type"": ""PassThrough"",
                    ""id"": ""77b17cb8-fe43-45f0-bb0e-3c66cfcc2d1b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Running"",
                    ""type"": ""Button"",
                    ""id"": ""68f106c6-bced-4add-97d0-735f39d39ca2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""546d40a0-6128-4754-a3b8-9da50c2ec5b3"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f66c7dbe-4f19-4554-adc4-9924fdf69714"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b7d29354-ff33-449c-a0b1-c6c023235776"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5ff9f893-1c17-44ed-9df7-c2224c16d529"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3a85821b-9339-4a14-8407-f69ead180476"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ed9b254a-1d4d-4c82-8659-66f52de13561"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": ""AxisDeadzone"",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f43bfb3c-0d27-4139-9f05-d46bcf351194"",
                    ""path"": ""<Pointer>/delta"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""66c46a66-ee82-4a34-bafb-b93aa60a41f8"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": """",
                    ""action"": ""CameraScroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b011d1b0-38c1-4246-ba84-a2905ac0f9fd"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Running"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""15febab7-12d9-4cd8-b127-20ec8e8919ac"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Running"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Attack
        m_Attack = asset.FindActionMap("Attack", throwIfNotFound: true);
        m_Attack_StrongAttack = m_Attack.FindAction("Strong Attack", throwIfNotFound: true);
        m_Attack_FastAttack = m_Attack.FindAction("Fast Attack", throwIfNotFound: true);
        m_Attack_Dodge = m_Attack.FindAction("Dodge", throwIfNotFound: true);
        m_Attack_Shield = m_Attack.FindAction("Shield", throwIfNotFound: true);
        m_Attack_CastSpell = m_Attack.FindAction("Cast Spell", throwIfNotFound: true);
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_Movement = m_Movement.FindAction("Movement", throwIfNotFound: true);
        m_Movement_Camera = m_Movement.FindAction("Camera", throwIfNotFound: true);
        m_Movement_CameraScroll = m_Movement.FindAction("CameraScroll", throwIfNotFound: true);
        m_Movement_Running = m_Movement.FindAction("Running", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Attack
    private readonly InputActionMap m_Attack;
    private IAttackActions m_AttackActionsCallbackInterface;
    private readonly InputAction m_Attack_StrongAttack;
    private readonly InputAction m_Attack_FastAttack;
    private readonly InputAction m_Attack_Dodge;
    private readonly InputAction m_Attack_Shield;
    private readonly InputAction m_Attack_CastSpell;
    public struct AttackActions
    {
        private @InputActions m_Wrapper;
        public AttackActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @StrongAttack => m_Wrapper.m_Attack_StrongAttack;
        public InputAction @FastAttack => m_Wrapper.m_Attack_FastAttack;
        public InputAction @Dodge => m_Wrapper.m_Attack_Dodge;
        public InputAction @Shield => m_Wrapper.m_Attack_Shield;
        public InputAction @CastSpell => m_Wrapper.m_Attack_CastSpell;
        public InputActionMap Get() { return m_Wrapper.m_Attack; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AttackActions set) { return set.Get(); }
        public void SetCallbacks(IAttackActions instance)
        {
            if (m_Wrapper.m_AttackActionsCallbackInterface != null)
            {
                @StrongAttack.started -= m_Wrapper.m_AttackActionsCallbackInterface.OnStrongAttack;
                @StrongAttack.performed -= m_Wrapper.m_AttackActionsCallbackInterface.OnStrongAttack;
                @StrongAttack.canceled -= m_Wrapper.m_AttackActionsCallbackInterface.OnStrongAttack;
                @FastAttack.started -= m_Wrapper.m_AttackActionsCallbackInterface.OnFastAttack;
                @FastAttack.performed -= m_Wrapper.m_AttackActionsCallbackInterface.OnFastAttack;
                @FastAttack.canceled -= m_Wrapper.m_AttackActionsCallbackInterface.OnFastAttack;
                @Dodge.started -= m_Wrapper.m_AttackActionsCallbackInterface.OnDodge;
                @Dodge.performed -= m_Wrapper.m_AttackActionsCallbackInterface.OnDodge;
                @Dodge.canceled -= m_Wrapper.m_AttackActionsCallbackInterface.OnDodge;
                @Shield.started -= m_Wrapper.m_AttackActionsCallbackInterface.OnShield;
                @Shield.performed -= m_Wrapper.m_AttackActionsCallbackInterface.OnShield;
                @Shield.canceled -= m_Wrapper.m_AttackActionsCallbackInterface.OnShield;
                @CastSpell.started -= m_Wrapper.m_AttackActionsCallbackInterface.OnCastSpell;
                @CastSpell.performed -= m_Wrapper.m_AttackActionsCallbackInterface.OnCastSpell;
                @CastSpell.canceled -= m_Wrapper.m_AttackActionsCallbackInterface.OnCastSpell;
            }
            m_Wrapper.m_AttackActionsCallbackInterface = instance;
            if (instance != null)
            {
                @StrongAttack.started += instance.OnStrongAttack;
                @StrongAttack.performed += instance.OnStrongAttack;
                @StrongAttack.canceled += instance.OnStrongAttack;
                @FastAttack.started += instance.OnFastAttack;
                @FastAttack.performed += instance.OnFastAttack;
                @FastAttack.canceled += instance.OnFastAttack;
                @Dodge.started += instance.OnDodge;
                @Dodge.performed += instance.OnDodge;
                @Dodge.canceled += instance.OnDodge;
                @Shield.started += instance.OnShield;
                @Shield.performed += instance.OnShield;
                @Shield.canceled += instance.OnShield;
                @CastSpell.started += instance.OnCastSpell;
                @CastSpell.performed += instance.OnCastSpell;
                @CastSpell.canceled += instance.OnCastSpell;
            }
        }
    }
    public AttackActions @Attack => new AttackActions(this);

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_Movement;
    private readonly InputAction m_Movement_Camera;
    private readonly InputAction m_Movement_CameraScroll;
    private readonly InputAction m_Movement_Running;
    public struct MovementActions
    {
        private @InputActions m_Wrapper;
        public MovementActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Movement_Movement;
        public InputAction @Camera => m_Wrapper.m_Movement_Camera;
        public InputAction @CameraScroll => m_Wrapper.m_Movement_CameraScroll;
        public InputAction @Running => m_Wrapper.m_Movement_Running;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnMovement;
                @Camera.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnCamera;
                @Camera.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnCamera;
                @Camera.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnCamera;
                @CameraScroll.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnCameraScroll;
                @CameraScroll.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnCameraScroll;
                @CameraScroll.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnCameraScroll;
                @Running.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnRunning;
                @Running.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnRunning;
                @Running.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnRunning;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Camera.started += instance.OnCamera;
                @Camera.performed += instance.OnCamera;
                @Camera.canceled += instance.OnCamera;
                @CameraScroll.started += instance.OnCameraScroll;
                @CameraScroll.performed += instance.OnCameraScroll;
                @CameraScroll.canceled += instance.OnCameraScroll;
                @Running.started += instance.OnRunning;
                @Running.performed += instance.OnRunning;
                @Running.canceled += instance.OnRunning;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);
    public interface IAttackActions
    {
        void OnStrongAttack(InputAction.CallbackContext context);
        void OnFastAttack(InputAction.CallbackContext context);
        void OnDodge(InputAction.CallbackContext context);
        void OnShield(InputAction.CallbackContext context);
        void OnCastSpell(InputAction.CallbackContext context);
    }
    public interface IMovementActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnCamera(InputAction.CallbackContext context);
        void OnCameraScroll(InputAction.CallbackContext context);
        void OnRunning(InputAction.CallbackContext context);
    }
}
