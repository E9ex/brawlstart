//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/forProjectiletrajectory/PlayerInputAction.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInputAction : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputAction"",
    ""maps"": [
        {
            ""name"": ""pActionmap"",
            ""id"": ""13c62352-61f8-4f44-bcdc-a21c99741374"",
            ""actions"": [
                {
                    ""name"": ""Mouselook"",
                    ""type"": ""Value"",
                    ""id"": ""7b98a32c-f277-4cb8-b3ca-2ea1a5b96581"",
                    ""expectedControlType"": ""Delta"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""106fc91b-5ac5-465b-9880-1a0803b69187"",
                    ""path"": ""<Pointer>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouselook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // pActionmap
        m_pActionmap = asset.FindActionMap("pActionmap", throwIfNotFound: true);
        m_pActionmap_Mouselook = m_pActionmap.FindAction("Mouselook", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // pActionmap
    private readonly InputActionMap m_pActionmap;
    private IPActionmapActions m_PActionmapActionsCallbackInterface;
    private readonly InputAction m_pActionmap_Mouselook;
    public struct PActionmapActions
    {
        private @PlayerInputAction m_Wrapper;
        public PActionmapActions(@PlayerInputAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @Mouselook => m_Wrapper.m_pActionmap_Mouselook;
        public InputActionMap Get() { return m_Wrapper.m_pActionmap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PActionmapActions set) { return set.Get(); }
        public void SetCallbacks(IPActionmapActions instance)
        {
            if (m_Wrapper.m_PActionmapActionsCallbackInterface != null)
            {
                @Mouselook.started -= m_Wrapper.m_PActionmapActionsCallbackInterface.OnMouselook;
                @Mouselook.performed -= m_Wrapper.m_PActionmapActionsCallbackInterface.OnMouselook;
                @Mouselook.canceled -= m_Wrapper.m_PActionmapActionsCallbackInterface.OnMouselook;
            }
            m_Wrapper.m_PActionmapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Mouselook.started += instance.OnMouselook;
                @Mouselook.performed += instance.OnMouselook;
                @Mouselook.canceled += instance.OnMouselook;
            }
        }
    }
    public PActionmapActions @pActionmap => new PActionmapActions(this);
    public interface IPActionmapActions
    {
        void OnMouselook(InputAction.CallbackContext context);
    }
}