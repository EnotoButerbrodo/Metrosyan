using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(SpellInventorySlotLink))]
public class SpellInventorySlot : MonoBehaviour
{
    
    public Action<SpellInventorySlot> Selected;
    public Action<SpellInventorySlot> Diselected;
    public SpellSlot Slot => _link.SpellSlot;
    public Timer SlotReloadTimer => _link.ReloadTimer;
    public bool IsSelected { get; private set; }

    private SpellInventorySlotLink _link;


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

    private void Awake()
    {
        _link = GetComponent<SpellInventorySlotLink>();
    }

    private void OnEnable()
    {
        _link.InputAction.action.Enable();
        _link.InputAction.action.performed += OnInput;
    }

    private void OnDisable()
    {
        _link.InputAction.action.Disable();
        _link.InputAction.action.performed -= OnInput;
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

}
