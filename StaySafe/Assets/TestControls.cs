// GENERATED AUTOMATICALLY FROM 'Assets/TestControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @TestControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @TestControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""TestControls"",
    ""maps"": [
        {
            ""name"": ""Main"",
            ""id"": ""8ae72501-b63e-489b-b909-bcc32a4f24ee"",
            ""actions"": [
                {
                    ""name"": ""Tap"",
                    ""type"": ""Button"",
                    ""id"": ""a054f084-aa15-4007-a100-81d393446efd"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Tap,SlowTap""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6da8cea5-7b28-455c-878f-fe74544931ab"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Main
        m_Main = asset.FindActionMap("Main", throwIfNotFound: true);
        m_Main_Tap = m_Main.FindAction("Tap", throwIfNotFound: true);
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

    // Main
    private readonly InputActionMap m_Main;
    private IMainActions m_MainActionsCallbackInterface;
    private readonly InputAction m_Main_Tap;
    public struct MainActions
    {
        private @TestControls m_Wrapper;
        public MainActions(@TestControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Tap => m_Wrapper.m_Main_Tap;
        public InputActionMap Get() { return m_Wrapper.m_Main; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainActions set) { return set.Get(); }
        public void SetCallbacks(IMainActions instance)
        {
            if (m_Wrapper.m_MainActionsCallbackInterface != null)
            {
                @Tap.started -= m_Wrapper.m_MainActionsCallbackInterface.OnTap;
                @Tap.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnTap;
                @Tap.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnTap;
            }
            m_Wrapper.m_MainActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Tap.started += instance.OnTap;
                @Tap.performed += instance.OnTap;
                @Tap.canceled += instance.OnTap;
            }
        }
    }
    public MainActions @Main => new MainActions(this);
    public interface IMainActions
    {
        void OnTap(InputAction.CallbackContext context);
    }
}
