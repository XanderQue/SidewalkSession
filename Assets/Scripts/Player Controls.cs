// GENERATED AUTOMATICALLY FROM 'Assets/Player Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerActionControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerActionControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player Controls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""25413bd1-71d1-4543-8af4-b14aa6f0efc3"",
            ""actions"": [
                {
                    ""name"": ""Jump(Space Bar)"",
                    ""type"": ""Button"",
                    ""id"": ""431a67b0-198e-463d-9806-bfac218b63e1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Slow Down"",
                    ""type"": ""Button"",
                    ""id"": ""b5c64ce9-d326-45cc-a297-e3b711d25fad"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Speed Up"",
                    ""type"": ""Button"",
                    ""id"": ""5db238be-e637-40aa-9f8b-90f9562fbf88"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""StopSlowingDown"",
                    ""type"": ""Button"",
                    ""id"": ""31838acd-51f9-4bf4-b58b-8f6d72f886ac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""6882453a-f665-4228-b532-8ecb77211a0d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Quit"",
                    ""type"": ""Button"",
                    ""id"": ""16841701-a23e-445a-a8d0-e4037e08f080"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""StartButton"",
                    ""type"": ""Button"",
                    ""id"": ""9ad0e9aa-9e5b-4db6-b260-31e0c8f8c1f8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""TouchInput"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c859c60e-7775-45c4-983a-4e1bb9eee3ed"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""TouchPress"",
                    ""type"": ""Button"",
                    ""id"": ""f95af774-1d89-4ef7-853e-f306ab2d62b1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""TouchPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ce916ded-2a7f-47df-a5c1-e517c2043231"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c3441c75-e9f1-469f-8491-6937e20588ef"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump(Space Bar)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ee411227-71d5-4bf2-8ada-99fce0ebddc3"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump(Space Bar)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e8ccf4c2-9e8d-4085-b4c9-7ce31dd9e3dc"",
                    ""path"": ""<WebGLGamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump(Space Bar)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a58a4ec8-235a-4599-b163-3b45dd608f98"",
                    ""path"": ""<WebGLGamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump(Space Bar)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bdfce78a-a289-4bd7-8b4f-0fe97ec597cd"",
                    ""path"": ""<XInputController>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump(Space Bar)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""71dfb140-a77a-4f32-b42d-ba5107b5e971"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Slow Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a23f7f6e-f661-4130-9c66-024b67c73801"",
                    ""path"": ""<XInputController>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Slow Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""16dd3916-c879-430a-abab-cfb3abf91c25"",
                    ""path"": ""<WebGLGamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Slow Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d8914346-a5d9-471c-9d4f-d0b38fa86794"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Speed Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2e5de9f7-6e5a-4713-874c-6e1e1b840e0d"",
                    ""path"": ""<XInputController>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Speed Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7a9ada38-17cd-4022-b68a-5a1231157d36"",
                    ""path"": ""<WebGLGamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Speed Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3ab7d540-25bf-4488-8f3a-aa71b0087d84"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StopSlowingDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""96ef1d37-970c-4bd2-8173-0f12d4232576"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2622068d-9baf-46a6-a993-40300bbb7a0c"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""42f76a7c-dd8d-4e76-b00b-0a4d121c2e0b"",
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
                    ""id"": ""624e88a3-f72f-4331-9c74-e2b8797754fb"",
                    ""path"": ""<WebGLGamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fad3a43d-156c-43ed-9aad-eda97246e76d"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bdc61363-89d5-4189-a0fb-46d7edb17d53"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""68630aaf-48c6-46ee-a14e-0016a0ee3273"",
                    ""path"": ""<WebGLGamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""df336bcf-1a48-4fc9-981f-a541190e6205"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3a16b9b4-e484-4f92-a942-23c8fdd332f1"",
                    ""path"": ""<WebGLGamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fb56af4f-b8a8-4ffe-88e7-957af094edbb"",
                    ""path"": ""<AndroidGamepadXboxController>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2fa6cfe4-7b91-45be-84eb-c4150991a61c"",
                    ""path"": ""<AndroidGamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9c0b3ff7-7d02-465d-894f-93357e98a729"",
                    ""path"": ""<Touchscreen>/primaryTouch"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e127c4b6-da4d-4319-bb1c-b6b57affced8"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""93b3419a-1f47-45e4-a0fc-a1a8dafd5434"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_JumpSpaceBar = m_Player.FindAction("Jump(Space Bar)", throwIfNotFound: true);
        m_Player_SlowDown = m_Player.FindAction("Slow Down", throwIfNotFound: true);
        m_Player_SpeedUp = m_Player.FindAction("Speed Up", throwIfNotFound: true);
        m_Player_StopSlowingDown = m_Player.FindAction("StopSlowingDown", throwIfNotFound: true);
        m_Player_Pause = m_Player.FindAction("Pause", throwIfNotFound: true);
        m_Player_Quit = m_Player.FindAction("Quit", throwIfNotFound: true);
        m_Player_StartButton = m_Player.FindAction("StartButton", throwIfNotFound: true);
        m_Player_TouchInput = m_Player.FindAction("TouchInput", throwIfNotFound: true);
        m_Player_TouchPress = m_Player.FindAction("TouchPress", throwIfNotFound: true);
        m_Player_TouchPosition = m_Player.FindAction("TouchPosition", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_JumpSpaceBar;
    private readonly InputAction m_Player_SlowDown;
    private readonly InputAction m_Player_SpeedUp;
    private readonly InputAction m_Player_StopSlowingDown;
    private readonly InputAction m_Player_Pause;
    private readonly InputAction m_Player_Quit;
    private readonly InputAction m_Player_StartButton;
    private readonly InputAction m_Player_TouchInput;
    private readonly InputAction m_Player_TouchPress;
    private readonly InputAction m_Player_TouchPosition;
    public struct PlayerActions
    {
        private @PlayerActionControls m_Wrapper;
        public PlayerActions(@PlayerActionControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @JumpSpaceBar => m_Wrapper.m_Player_JumpSpaceBar;
        public InputAction @SlowDown => m_Wrapper.m_Player_SlowDown;
        public InputAction @SpeedUp => m_Wrapper.m_Player_SpeedUp;
        public InputAction @StopSlowingDown => m_Wrapper.m_Player_StopSlowingDown;
        public InputAction @Pause => m_Wrapper.m_Player_Pause;
        public InputAction @Quit => m_Wrapper.m_Player_Quit;
        public InputAction @StartButton => m_Wrapper.m_Player_StartButton;
        public InputAction @TouchInput => m_Wrapper.m_Player_TouchInput;
        public InputAction @TouchPress => m_Wrapper.m_Player_TouchPress;
        public InputAction @TouchPosition => m_Wrapper.m_Player_TouchPosition;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @JumpSpaceBar.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJumpSpaceBar;
                @JumpSpaceBar.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJumpSpaceBar;
                @JumpSpaceBar.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJumpSpaceBar;
                @SlowDown.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSlowDown;
                @SlowDown.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSlowDown;
                @SlowDown.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSlowDown;
                @SpeedUp.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpeedUp;
                @SpeedUp.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpeedUp;
                @SpeedUp.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpeedUp;
                @StopSlowingDown.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStopSlowingDown;
                @StopSlowingDown.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStopSlowingDown;
                @StopSlowingDown.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStopSlowingDown;
                @Pause.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Quit.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnQuit;
                @Quit.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnQuit;
                @Quit.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnQuit;
                @StartButton.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStartButton;
                @StartButton.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStartButton;
                @StartButton.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStartButton;
                @TouchInput.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchInput;
                @TouchInput.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchInput;
                @TouchInput.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchInput;
                @TouchPress.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchPress;
                @TouchPress.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchPress;
                @TouchPress.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchPress;
                @TouchPosition.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchPosition;
                @TouchPosition.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchPosition;
                @TouchPosition.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchPosition;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @JumpSpaceBar.started += instance.OnJumpSpaceBar;
                @JumpSpaceBar.performed += instance.OnJumpSpaceBar;
                @JumpSpaceBar.canceled += instance.OnJumpSpaceBar;
                @SlowDown.started += instance.OnSlowDown;
                @SlowDown.performed += instance.OnSlowDown;
                @SlowDown.canceled += instance.OnSlowDown;
                @SpeedUp.started += instance.OnSpeedUp;
                @SpeedUp.performed += instance.OnSpeedUp;
                @SpeedUp.canceled += instance.OnSpeedUp;
                @StopSlowingDown.started += instance.OnStopSlowingDown;
                @StopSlowingDown.performed += instance.OnStopSlowingDown;
                @StopSlowingDown.canceled += instance.OnStopSlowingDown;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Quit.started += instance.OnQuit;
                @Quit.performed += instance.OnQuit;
                @Quit.canceled += instance.OnQuit;
                @StartButton.started += instance.OnStartButton;
                @StartButton.performed += instance.OnStartButton;
                @StartButton.canceled += instance.OnStartButton;
                @TouchInput.started += instance.OnTouchInput;
                @TouchInput.performed += instance.OnTouchInput;
                @TouchInput.canceled += instance.OnTouchInput;
                @TouchPress.started += instance.OnTouchPress;
                @TouchPress.performed += instance.OnTouchPress;
                @TouchPress.canceled += instance.OnTouchPress;
                @TouchPosition.started += instance.OnTouchPosition;
                @TouchPosition.performed += instance.OnTouchPosition;
                @TouchPosition.canceled += instance.OnTouchPosition;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnJumpSpaceBar(InputAction.CallbackContext context);
        void OnSlowDown(InputAction.CallbackContext context);
        void OnSpeedUp(InputAction.CallbackContext context);
        void OnStopSlowingDown(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnQuit(InputAction.CallbackContext context);
        void OnStartButton(InputAction.CallbackContext context);
        void OnTouchInput(InputAction.CallbackContext context);
        void OnTouchPress(InputAction.CallbackContext context);
        void OnTouchPosition(InputAction.CallbackContext context);
    }
}
