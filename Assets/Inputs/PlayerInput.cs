// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""onFoot"",
            ""id"": ""0cd91ea8-7dee-4cb3-a9d4-1535b0131ba9"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""63b74b90-edf2-4cbc-996a-492b5a3a4dba"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Mouse Look"",
                    ""type"": ""Value"",
                    ""id"": ""75452d1a-58ad-4671-add5-68af65c0a187"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""37299645-d8ed-4aba-aadc-dc9c2733c031"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""3c28f226-64b6-4096-861f-75f5811fccd6"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ac771035-bc6e-449d-938d-73ff10fcde73"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2eb84497-43a4-42cd-890b-8ba6add2fecc"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9a4328d1-6766-4756-a214-8d3fa1997913"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a7baba78-700d-48cd-8d1c-b09b62ce4c3b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1614e185-aa50-464e-a6ad-cfbad24b5402"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouse Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8bb312f0-385e-4817-aead-d673193853db"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""extra"",
            ""id"": ""727175a9-6383-4a21-bcc7-c20acf8a48f6"",
            ""actions"": [
                {
                    ""name"": ""Escape"",
                    ""type"": ""Button"",
                    ""id"": ""b6d18e09-478a-499b-a843-fb0ec3780046"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Scoreboard"",
                    ""type"": ""Button"",
                    ""id"": ""73667a5a-ad39-417b-bd99-fe14d8595588"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""34c073ec-81d6-4d54-8c11-2162c243d9bc"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4d2fc387-3e0f-44a7-bce9-996d80491810"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scoreboard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""weaponHandling"",
            ""id"": ""dd7a0643-4172-431c-9391-fff015497e89"",
            ""actions"": [
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""a8760c0f-47be-40cf-a8c5-cb1ca6873b91"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""1faa4653-f901-4d41-8c5c-0d64680e81f8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""39253a06-8977-4dc2-9e8f-016a40d651bb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Weapon1"",
                    ""type"": ""Button"",
                    ""id"": ""336e530d-418e-4872-b120-b8253737a424"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Weapon2"",
                    ""type"": ""Button"",
                    ""id"": ""14351e7c-3450-43df-b875-12971a32f2e6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Weapon3"",
                    ""type"": ""Button"",
                    ""id"": ""db896471-8e3f-4f34-b6eb-a89956a46bfc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Weapon4"",
                    ""type"": ""Button"",
                    ""id"": ""62ef9b25-df8a-4095-b3a2-86cd42b17f0d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""42642ab2-780a-43dc-90ef-5b40642f21b7"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b5603201-def4-48a8-83c0-20fac55dd307"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""55afe457-9e25-4fd6-9d6a-4e707ab3e714"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Weapon1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a986a714-06c6-4827-9abb-2ac2b5bd619a"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Weapon2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""60d4cd57-2cd2-47db-bfe9-116acdb35790"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Weapon3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c6d08d2f-d579-4574-96bc-af82bd8ade10"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Weapon4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a0b850f0-b068-4e00-bfe1-2ef1f4a7f175"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // onFoot
        m_onFoot = asset.FindActionMap("onFoot", throwIfNotFound: true);
        m_onFoot_Move = m_onFoot.FindAction("Move", throwIfNotFound: true);
        m_onFoot_MouseLook = m_onFoot.FindAction("Mouse Look", throwIfNotFound: true);
        m_onFoot_Jump = m_onFoot.FindAction("Jump", throwIfNotFound: true);
        // extra
        m_extra = asset.FindActionMap("extra", throwIfNotFound: true);
        m_extra_Escape = m_extra.FindAction("Escape", throwIfNotFound: true);
        m_extra_Scoreboard = m_extra.FindAction("Scoreboard", throwIfNotFound: true);
        // weaponHandling
        m_weaponHandling = asset.FindActionMap("weaponHandling", throwIfNotFound: true);
        m_weaponHandling_Fire = m_weaponHandling.FindAction("Fire", throwIfNotFound: true);
        m_weaponHandling_Aim = m_weaponHandling.FindAction("Aim", throwIfNotFound: true);
        m_weaponHandling_Reload = m_weaponHandling.FindAction("Reload", throwIfNotFound: true);
        m_weaponHandling_Weapon1 = m_weaponHandling.FindAction("Weapon1", throwIfNotFound: true);
        m_weaponHandling_Weapon2 = m_weaponHandling.FindAction("Weapon2", throwIfNotFound: true);
        m_weaponHandling_Weapon3 = m_weaponHandling.FindAction("Weapon3", throwIfNotFound: true);
        m_weaponHandling_Weapon4 = m_weaponHandling.FindAction("Weapon4", throwIfNotFound: true);
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

    // onFoot
    private readonly InputActionMap m_onFoot;
    private IOnFootActions m_OnFootActionsCallbackInterface;
    private readonly InputAction m_onFoot_Move;
    private readonly InputAction m_onFoot_MouseLook;
    private readonly InputAction m_onFoot_Jump;
    public struct OnFootActions
    {
        private @PlayerInput m_Wrapper;
        public OnFootActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_onFoot_Move;
        public InputAction @MouseLook => m_Wrapper.m_onFoot_MouseLook;
        public InputAction @Jump => m_Wrapper.m_onFoot_Jump;
        public InputActionMap Get() { return m_Wrapper.m_onFoot; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(OnFootActions set) { return set.Get(); }
        public void SetCallbacks(IOnFootActions instance)
        {
            if (m_Wrapper.m_OnFootActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_OnFootActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_OnFootActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_OnFootActionsCallbackInterface.OnMove;
                @MouseLook.started -= m_Wrapper.m_OnFootActionsCallbackInterface.OnMouseLook;
                @MouseLook.performed -= m_Wrapper.m_OnFootActionsCallbackInterface.OnMouseLook;
                @MouseLook.canceled -= m_Wrapper.m_OnFootActionsCallbackInterface.OnMouseLook;
                @Jump.started -= m_Wrapper.m_OnFootActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_OnFootActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_OnFootActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_OnFootActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @MouseLook.started += instance.OnMouseLook;
                @MouseLook.performed += instance.OnMouseLook;
                @MouseLook.canceled += instance.OnMouseLook;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public OnFootActions @onFoot => new OnFootActions(this);

    // extra
    private readonly InputActionMap m_extra;
    private IExtraActions m_ExtraActionsCallbackInterface;
    private readonly InputAction m_extra_Escape;
    private readonly InputAction m_extra_Scoreboard;
    public struct ExtraActions
    {
        private @PlayerInput m_Wrapper;
        public ExtraActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Escape => m_Wrapper.m_extra_Escape;
        public InputAction @Scoreboard => m_Wrapper.m_extra_Scoreboard;
        public InputActionMap Get() { return m_Wrapper.m_extra; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ExtraActions set) { return set.Get(); }
        public void SetCallbacks(IExtraActions instance)
        {
            if (m_Wrapper.m_ExtraActionsCallbackInterface != null)
            {
                @Escape.started -= m_Wrapper.m_ExtraActionsCallbackInterface.OnEscape;
                @Escape.performed -= m_Wrapper.m_ExtraActionsCallbackInterface.OnEscape;
                @Escape.canceled -= m_Wrapper.m_ExtraActionsCallbackInterface.OnEscape;
                @Scoreboard.started -= m_Wrapper.m_ExtraActionsCallbackInterface.OnScoreboard;
                @Scoreboard.performed -= m_Wrapper.m_ExtraActionsCallbackInterface.OnScoreboard;
                @Scoreboard.canceled -= m_Wrapper.m_ExtraActionsCallbackInterface.OnScoreboard;
            }
            m_Wrapper.m_ExtraActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Escape.started += instance.OnEscape;
                @Escape.performed += instance.OnEscape;
                @Escape.canceled += instance.OnEscape;
                @Scoreboard.started += instance.OnScoreboard;
                @Scoreboard.performed += instance.OnScoreboard;
                @Scoreboard.canceled += instance.OnScoreboard;
            }
        }
    }
    public ExtraActions @extra => new ExtraActions(this);

    // weaponHandling
    private readonly InputActionMap m_weaponHandling;
    private IWeaponHandlingActions m_WeaponHandlingActionsCallbackInterface;
    private readonly InputAction m_weaponHandling_Fire;
    private readonly InputAction m_weaponHandling_Aim;
    private readonly InputAction m_weaponHandling_Reload;
    private readonly InputAction m_weaponHandling_Weapon1;
    private readonly InputAction m_weaponHandling_Weapon2;
    private readonly InputAction m_weaponHandling_Weapon3;
    private readonly InputAction m_weaponHandling_Weapon4;
    public struct WeaponHandlingActions
    {
        private @PlayerInput m_Wrapper;
        public WeaponHandlingActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Fire => m_Wrapper.m_weaponHandling_Fire;
        public InputAction @Aim => m_Wrapper.m_weaponHandling_Aim;
        public InputAction @Reload => m_Wrapper.m_weaponHandling_Reload;
        public InputAction @Weapon1 => m_Wrapper.m_weaponHandling_Weapon1;
        public InputAction @Weapon2 => m_Wrapper.m_weaponHandling_Weapon2;
        public InputAction @Weapon3 => m_Wrapper.m_weaponHandling_Weapon3;
        public InputAction @Weapon4 => m_Wrapper.m_weaponHandling_Weapon4;
        public InputActionMap Get() { return m_Wrapper.m_weaponHandling; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(WeaponHandlingActions set) { return set.Get(); }
        public void SetCallbacks(IWeaponHandlingActions instance)
        {
            if (m_Wrapper.m_WeaponHandlingActionsCallbackInterface != null)
            {
                @Fire.started -= m_Wrapper.m_WeaponHandlingActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_WeaponHandlingActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_WeaponHandlingActionsCallbackInterface.OnFire;
                @Aim.started -= m_Wrapper.m_WeaponHandlingActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_WeaponHandlingActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_WeaponHandlingActionsCallbackInterface.OnAim;
                @Reload.started -= m_Wrapper.m_WeaponHandlingActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_WeaponHandlingActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_WeaponHandlingActionsCallbackInterface.OnReload;
                @Weapon1.started -= m_Wrapper.m_WeaponHandlingActionsCallbackInterface.OnWeapon1;
                @Weapon1.performed -= m_Wrapper.m_WeaponHandlingActionsCallbackInterface.OnWeapon1;
                @Weapon1.canceled -= m_Wrapper.m_WeaponHandlingActionsCallbackInterface.OnWeapon1;
                @Weapon2.started -= m_Wrapper.m_WeaponHandlingActionsCallbackInterface.OnWeapon2;
                @Weapon2.performed -= m_Wrapper.m_WeaponHandlingActionsCallbackInterface.OnWeapon2;
                @Weapon2.canceled -= m_Wrapper.m_WeaponHandlingActionsCallbackInterface.OnWeapon2;
                @Weapon3.started -= m_Wrapper.m_WeaponHandlingActionsCallbackInterface.OnWeapon3;
                @Weapon3.performed -= m_Wrapper.m_WeaponHandlingActionsCallbackInterface.OnWeapon3;
                @Weapon3.canceled -= m_Wrapper.m_WeaponHandlingActionsCallbackInterface.OnWeapon3;
                @Weapon4.started -= m_Wrapper.m_WeaponHandlingActionsCallbackInterface.OnWeapon4;
                @Weapon4.performed -= m_Wrapper.m_WeaponHandlingActionsCallbackInterface.OnWeapon4;
                @Weapon4.canceled -= m_Wrapper.m_WeaponHandlingActionsCallbackInterface.OnWeapon4;
            }
            m_Wrapper.m_WeaponHandlingActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
                @Weapon1.started += instance.OnWeapon1;
                @Weapon1.performed += instance.OnWeapon1;
                @Weapon1.canceled += instance.OnWeapon1;
                @Weapon2.started += instance.OnWeapon2;
                @Weapon2.performed += instance.OnWeapon2;
                @Weapon2.canceled += instance.OnWeapon2;
                @Weapon3.started += instance.OnWeapon3;
                @Weapon3.performed += instance.OnWeapon3;
                @Weapon3.canceled += instance.OnWeapon3;
                @Weapon4.started += instance.OnWeapon4;
                @Weapon4.performed += instance.OnWeapon4;
                @Weapon4.canceled += instance.OnWeapon4;
            }
        }
    }
    public WeaponHandlingActions @weaponHandling => new WeaponHandlingActions(this);
    public interface IOnFootActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnMouseLook(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
    public interface IExtraActions
    {
        void OnEscape(InputAction.CallbackContext context);
        void OnScoreboard(InputAction.CallbackContext context);
    }
    public interface IWeaponHandlingActions
    {
        void OnFire(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnWeapon1(InputAction.CallbackContext context);
        void OnWeapon2(InputAction.CallbackContext context);
        void OnWeapon3(InputAction.CallbackContext context);
        void OnWeapon4(InputAction.CallbackContext context);
    }
}
