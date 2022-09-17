using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpellInventorySlot : MonoBehaviour
{
    
    public Action<SpellInventorySlot> Selected;
    public Action<SpellInventorySlot> Diselected;
    public SpellSlot Slot => _slot;
    public bool IsSelected { get; private set; }

    [SerializeField] private SpellSlot _slot;
    [SerializeField] private InputActionReference _input;

    private void OnEnable()
    {
        _input.action.Enable();
        _input.action.performed += OnInput;
    }

    private void OnDisable()
    {
        _input.action.Disable();
        _input.action.performed -= OnInput;
    }
    private void OnInput(InputAction.CallbackContext c)
    {
        if (IsSelected)
        {
            Diselect();
        }
        else
        {
            Select();
        }
    }

    public void Select()
    {
        IsSelected = true;

        Selected?.Invoke(this);
    }
    
    public void Diselect()
    {
        IsSelected = false;

        Diselected?.Invoke(this);
    }
}

