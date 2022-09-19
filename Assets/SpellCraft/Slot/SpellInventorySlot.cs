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
    public bool IsReloading => Slot?.CurrentItem?.Reloading is null ? false : Slot.CurrentItem.Reloading;

    public bool IsEmpty => _link.SpellSlot.CurrentItem == null;

    private SpellInventorySlotLink _link;


    public void Select()
    {
        if (IsEmpty)
        {
            return;
        }

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




}
