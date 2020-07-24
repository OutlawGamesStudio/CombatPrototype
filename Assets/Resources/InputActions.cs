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
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fast Attack"",
                    ""type"": ""Button"",
                    ""id"": ""83dad013-32c0-4bb2-b29f-cb956a8e9b79"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
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
                    ""name"": ""Roll"",
                    ""type"": ""Button"",
                    ""id"": ""5d68865b-f486-46b8-af66-9e2d5fbab2eb"",
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
                },
                {
                    ""name"": ""Lock On"",
                    ""type"": ""Button"",
                    ""id"": ""edb13d46-29dd-4e85-b701-24257b5ac32b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Sheath"",
                    ""type"": ""Button"",
                    ""id"": ""2c864bf8-b5de-4f14-a2fc-288d34868658"",
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
                    ""path"": ""<Keyboard>/leftCtrl"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""8017f8e4-a90a-4108-8975-684fcd666e77"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e1f0a950-817b-4c3d-8f85-6373582bf6bd"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""75a6aec9-e760-4d04-8cc4-5d9c784b31aa"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Lock On"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""96835622-283d-4d8e-9bab-2d1e34deab21"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Lock On"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""70076e72-fc1d-4e93-bac0-bc1dde5985e3"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sheath"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5a919e0c-5269-48a0-af77-88a7a7ea6945"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sheath"",
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
                    ""id"": ""002fdc40-2772-4663-a261-0282ebc5862b"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ed9b254a-1d4d-4c82-8659-66f52de13561"",
                    ""path"": ""<Gamepad>/rightStick"",
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
        },
        {
            ""name"": ""Interface"",
            ""id"": ""097edc0f-4c60-43e5-91b0-01841de90d0e"",
            ""actions"": [
                {
                    ""name"": ""Activate"",
                    ""type"": ""Button"",
                    ""id"": ""fcf16655-82a0-4b02-95dd-548b2d0a6cbc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""80b69b76-d4ab-442b-b487-1f0ef557b236"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Quest Journal"",
                    ""type"": ""Button"",
                    ""id"": ""777ef876-5d88-4972-b7ba-2e3449e03c73"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""00588904-3cba-460a-9a26-1d1d9de2dd8a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Cast Spell"",
                    ""type"": ""Button"",
                    ""id"": ""3ea909b8-5318-4753-81ac-b3729e82ad17"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Menu Up"",
                    ""type"": ""Button"",
                    ""id"": ""e5d9c4af-9b88-4f42-b1b9-f78428ca6639"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Menu Down"",
                    ""type"": ""Button"",
                    ""id"": ""4e8b011f-9697-4f2e-89fe-90d6a58ebef4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Menu Left"",
                    ""type"": ""Button"",
                    ""id"": ""90bf388e-cb56-4dfa-bfeb-49c8176e39a9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Menu Right"",
                    ""type"": ""Button"",
                    ""id"": ""25c34b38-7561-414a-9dc1-9b21665a3abc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6b7c92f2-9f7e-4923-84db-c9b062d0e3d6"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Activate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a7e55606-6815-4e8a-af91-10040d13b20d"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Activate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e5883b98-a429-4e60-a574-84a909f7be41"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""410bc676-ec25-40ee-a0a3-9610a44551d9"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e4b0ac39-83fc-4a35-8733-1c0886d602c1"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quest Journal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4be90fb4-2214-4f86-b2a3-ebd98531f4f7"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quest Journal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eb6131a6-43bc-4d13-8937-47e90b315875"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b6c316ca-abb3-4083-8f5e-b912d49c87d2"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c69090ec-ac6e-4a61-9de6-ccef04be1bf5"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cast Spell"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7e6c80e8-03ec-4b75-93bf-29ed1f0a3fd7"",
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
                    ""id"": ""4fbd8764-2abe-49b9-8dbb-3263e56abafb"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""457a1c7d-6fdd-4e27-8c3a-6d6d9d786ac8"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""80fa010c-beb2-4452-8e5b-8cb8c2a8dccd"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""73e177a7-dd62-485f-9f6d-2a00326e37c7"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""73e19bc6-9fd0-4ac4-b235-e1ec70fac15a"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""90243150-bf9d-4858-9879-ee066acb5fcc"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""08f128d8-7f90-4c36-99a8-5aae17923d5e"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""440fff4c-ce64-45ed-9466-f032041c8828"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu Right"",
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
        m_Attack_Roll = m_Attack.FindAction("Roll", throwIfNotFound: true);
        m_Attack_Shield = m_Attack.FindAction("Shield", throwIfNotFound: true);
        m_Attack_CastSpell = m_Attack.FindAction("Cast Spell", throwIfNotFound: true);
        m_Attack_LockOn = m_Attack.FindAction("Lock On", throwIfNotFound: true);
        m_Attack_Sheath = m_Attack.FindAction("Sheath", throwIfNotFound: true);
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_Movement = m_Movement.FindAction("Movement", throwIfNotFound: true);
        m_Movement_Camera = m_Movement.FindAction("Camera", throwIfNotFound: true);
        m_Movement_CameraScroll = m_Movement.FindAction("CameraScroll", throwIfNotFound: true);
        m_Movement_Running = m_Movement.FindAction("Running", throwIfNotFound: true);
        // Interface
        m_Interface = asset.FindActionMap("Interface", throwIfNotFound: true);
        m_Interface_Activate = m_Interface.FindAction("Activate", throwIfNotFound: true);
        m_Interface_Pause = m_Interface.FindAction("Pause", throwIfNotFound: true);
        m_Interface_QuestJournal = m_Interface.FindAction("Quest Journal", throwIfNotFound: true);
        m_Interface_Inventory = m_Interface.FindAction("Inventory", throwIfNotFound: true);
        m_Interface_CastSpell = m_Interface.FindAction("Cast Spell", throwIfNotFound: true);
        m_Interface_MenuUp = m_Interface.FindAction("Menu Up", throwIfNotFound: true);
        m_Interface_MenuDown = m_Interface.FindAction("Menu Down", throwIfNotFound: true);
        m_Interface_MenuLeft = m_Interface.FindAction("Menu Left", throwIfNotFound: true);
        m_Interface_MenuRight = m_Interface.FindAction("Menu Right", throwIfNotFound: true);
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
    private readonly InputAction m_Attack_Roll;
    private readonly InputAction m_Attack_Shield;
    private readonly InputAction m_Attack_CastSpell;
    private readonly InputAction m_Attack_LockOn;
    private readonly InputAction m_Attack_Sheath;
    public struct AttackActions
    {
        private @InputActions m_Wrapper;
        public AttackActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @StrongAttack => m_Wrapper.m_Attack_StrongAttack;
        public InputAction @FastAttack => m_Wrapper.m_Attack_FastAttack;
        public InputAction @Dodge => m_Wrapper.m_Attack_Dodge;
        public InputAction @Roll => m_Wrapper.m_Attack_Roll;
        public InputAction @Shield => m_Wrapper.m_Attack_Shield;
        public InputAction @CastSpell => m_Wrapper.m_Attack_CastSpell;
        public InputAction @LockOn => m_Wrapper.m_Attack_LockOn;
        public InputAction @Sheath => m_Wrapper.m_Attack_Sheath;
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
                @Roll.started -= m_Wrapper.m_AttackActionsCallbackInterface.OnRoll;
                @Roll.performed -= m_Wrapper.m_AttackActionsCallbackInterface.OnRoll;
                @Roll.canceled -= m_Wrapper.m_AttackActionsCallbackInterface.OnRoll;
                @Shield.started -= m_Wrapper.m_AttackActionsCallbackInterface.OnShield;
                @Shield.performed -= m_Wrapper.m_AttackActionsCallbackInterface.OnShield;
                @Shield.canceled -= m_Wrapper.m_AttackActionsCallbackInterface.OnShield;
                @CastSpell.started -= m_Wrapper.m_AttackActionsCallbackInterface.OnCastSpell;
                @CastSpell.performed -= m_Wrapper.m_AttackActionsCallbackInterface.OnCastSpell;
                @CastSpell.canceled -= m_Wrapper.m_AttackActionsCallbackInterface.OnCastSpell;
                @LockOn.started -= m_Wrapper.m_AttackActionsCallbackInterface.OnLockOn;
                @LockOn.performed -= m_Wrapper.m_AttackActionsCallbackInterface.OnLockOn;
                @LockOn.canceled -= m_Wrapper.m_AttackActionsCallbackInterface.OnLockOn;
                @Sheath.started -= m_Wrapper.m_AttackActionsCallbackInterface.OnSheath;
                @Sheath.performed -= m_Wrapper.m_AttackActionsCallbackInterface.OnSheath;
                @Sheath.canceled -= m_Wrapper.m_AttackActionsCallbackInterface.OnSheath;
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
                @Roll.started += instance.OnRoll;
                @Roll.performed += instance.OnRoll;
                @Roll.canceled += instance.OnRoll;
                @Shield.started += instance.OnShield;
                @Shield.performed += instance.OnShield;
                @Shield.canceled += instance.OnShield;
                @CastSpell.started += instance.OnCastSpell;
                @CastSpell.performed += instance.OnCastSpell;
                @CastSpell.canceled += instance.OnCastSpell;
                @LockOn.started += instance.OnLockOn;
                @LockOn.performed += instance.OnLockOn;
                @LockOn.canceled += instance.OnLockOn;
                @Sheath.started += instance.OnSheath;
                @Sheath.performed += instance.OnSheath;
                @Sheath.canceled += instance.OnSheath;
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

    // Interface
    private readonly InputActionMap m_Interface;
    private IInterfaceActions m_InterfaceActionsCallbackInterface;
    private readonly InputAction m_Interface_Activate;
    private readonly InputAction m_Interface_Pause;
    private readonly InputAction m_Interface_QuestJournal;
    private readonly InputAction m_Interface_Inventory;
    private readonly InputAction m_Interface_CastSpell;
    private readonly InputAction m_Interface_MenuUp;
    private readonly InputAction m_Interface_MenuDown;
    private readonly InputAction m_Interface_MenuLeft;
    private readonly InputAction m_Interface_MenuRight;
    public struct InterfaceActions
    {
        private @InputActions m_Wrapper;
        public InterfaceActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Activate => m_Wrapper.m_Interface_Activate;
        public InputAction @Pause => m_Wrapper.m_Interface_Pause;
        public InputAction @QuestJournal => m_Wrapper.m_Interface_QuestJournal;
        public InputAction @Inventory => m_Wrapper.m_Interface_Inventory;
        public InputAction @CastSpell => m_Wrapper.m_Interface_CastSpell;
        public InputAction @MenuUp => m_Wrapper.m_Interface_MenuUp;
        public InputAction @MenuDown => m_Wrapper.m_Interface_MenuDown;
        public InputAction @MenuLeft => m_Wrapper.m_Interface_MenuLeft;
        public InputAction @MenuRight => m_Wrapper.m_Interface_MenuRight;
        public InputActionMap Get() { return m_Wrapper.m_Interface; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InterfaceActions set) { return set.Get(); }
        public void SetCallbacks(IInterfaceActions instance)
        {
            if (m_Wrapper.m_InterfaceActionsCallbackInterface != null)
            {
                @Activate.started -= m_Wrapper.m_InterfaceActionsCallbackInterface.OnActivate;
                @Activate.performed -= m_Wrapper.m_InterfaceActionsCallbackInterface.OnActivate;
                @Activate.canceled -= m_Wrapper.m_InterfaceActionsCallbackInterface.OnActivate;
                @Pause.started -= m_Wrapper.m_InterfaceActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_InterfaceActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_InterfaceActionsCallbackInterface.OnPause;
                @QuestJournal.started -= m_Wrapper.m_InterfaceActionsCallbackInterface.OnQuestJournal;
                @QuestJournal.performed -= m_Wrapper.m_InterfaceActionsCallbackInterface.OnQuestJournal;
                @QuestJournal.canceled -= m_Wrapper.m_InterfaceActionsCallbackInterface.OnQuestJournal;
                @Inventory.started -= m_Wrapper.m_InterfaceActionsCallbackInterface.OnInventory;
                @Inventory.performed -= m_Wrapper.m_InterfaceActionsCallbackInterface.OnInventory;
                @Inventory.canceled -= m_Wrapper.m_InterfaceActionsCallbackInterface.OnInventory;
                @CastSpell.started -= m_Wrapper.m_InterfaceActionsCallbackInterface.OnCastSpell;
                @CastSpell.performed -= m_Wrapper.m_InterfaceActionsCallbackInterface.OnCastSpell;
                @CastSpell.canceled -= m_Wrapper.m_InterfaceActionsCallbackInterface.OnCastSpell;
                @MenuUp.started -= m_Wrapper.m_InterfaceActionsCallbackInterface.OnMenuUp;
                @MenuUp.performed -= m_Wrapper.m_InterfaceActionsCallbackInterface.OnMenuUp;
                @MenuUp.canceled -= m_Wrapper.m_InterfaceActionsCallbackInterface.OnMenuUp;
                @MenuDown.started -= m_Wrapper.m_InterfaceActionsCallbackInterface.OnMenuDown;
                @MenuDown.performed -= m_Wrapper.m_InterfaceActionsCallbackInterface.OnMenuDown;
                @MenuDown.canceled -= m_Wrapper.m_InterfaceActionsCallbackInterface.OnMenuDown;
                @MenuLeft.started -= m_Wrapper.m_InterfaceActionsCallbackInterface.OnMenuLeft;
                @MenuLeft.performed -= m_Wrapper.m_InterfaceActionsCallbackInterface.OnMenuLeft;
                @MenuLeft.canceled -= m_Wrapper.m_InterfaceActionsCallbackInterface.OnMenuLeft;
                @MenuRight.started -= m_Wrapper.m_InterfaceActionsCallbackInterface.OnMenuRight;
                @MenuRight.performed -= m_Wrapper.m_InterfaceActionsCallbackInterface.OnMenuRight;
                @MenuRight.canceled -= m_Wrapper.m_InterfaceActionsCallbackInterface.OnMenuRight;
            }
            m_Wrapper.m_InterfaceActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Activate.started += instance.OnActivate;
                @Activate.performed += instance.OnActivate;
                @Activate.canceled += instance.OnActivate;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @QuestJournal.started += instance.OnQuestJournal;
                @QuestJournal.performed += instance.OnQuestJournal;
                @QuestJournal.canceled += instance.OnQuestJournal;
                @Inventory.started += instance.OnInventory;
                @Inventory.performed += instance.OnInventory;
                @Inventory.canceled += instance.OnInventory;
                @CastSpell.started += instance.OnCastSpell;
                @CastSpell.performed += instance.OnCastSpell;
                @CastSpell.canceled += instance.OnCastSpell;
                @MenuUp.started += instance.OnMenuUp;
                @MenuUp.performed += instance.OnMenuUp;
                @MenuUp.canceled += instance.OnMenuUp;
                @MenuDown.started += instance.OnMenuDown;
                @MenuDown.performed += instance.OnMenuDown;
                @MenuDown.canceled += instance.OnMenuDown;
                @MenuLeft.started += instance.OnMenuLeft;
                @MenuLeft.performed += instance.OnMenuLeft;
                @MenuLeft.canceled += instance.OnMenuLeft;
                @MenuRight.started += instance.OnMenuRight;
                @MenuRight.performed += instance.OnMenuRight;
                @MenuRight.canceled += instance.OnMenuRight;
            }
        }
    }
    public InterfaceActions @Interface => new InterfaceActions(this);
    public interface IAttackActions
    {
        void OnStrongAttack(InputAction.CallbackContext context);
        void OnFastAttack(InputAction.CallbackContext context);
        void OnDodge(InputAction.CallbackContext context);
        void OnRoll(InputAction.CallbackContext context);
        void OnShield(InputAction.CallbackContext context);
        void OnCastSpell(InputAction.CallbackContext context);
        void OnLockOn(InputAction.CallbackContext context);
        void OnSheath(InputAction.CallbackContext context);
    }
    public interface IMovementActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnCamera(InputAction.CallbackContext context);
        void OnCameraScroll(InputAction.CallbackContext context);
        void OnRunning(InputAction.CallbackContext context);
    }
    public interface IInterfaceActions
    {
        void OnActivate(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnQuestJournal(InputAction.CallbackContext context);
        void OnInventory(InputAction.CallbackContext context);
        void OnCastSpell(InputAction.CallbackContext context);
        void OnMenuUp(InputAction.CallbackContext context);
        void OnMenuDown(InputAction.CallbackContext context);
        void OnMenuLeft(InputAction.CallbackContext context);
        void OnMenuRight(InputAction.CallbackContext context);
    }
}
