using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class SpellInventory : MonoBehaviour
{
    public event Action<SpellInventorySlot> SlotSelected;
    public event Action<SpellInventorySlot> SlotDiselected;

    

    public event Action SelectedSlotReloading;
    public bool IsSpellSelected => _selectedSlot != null;
    public SpellInventorySlot SelectedSlot => _selectedSlot ?? null;

    public int SlotsCount => _slots.Count;
    [SerializeField] private List<SpellInventorySlot> _slots;

    [SerializeField] private SpellInventorySlot _selectedSlot;


    public void SelectSlot(int index)
    {
        if (_slots[index].IsReloading)
        {
            SelectedSlotReloading?.Invoke();
            return;
        }

        _slots[index].Select();
    }

    public void DiselectSlot(int index)
    {
        _slots[index].Diselect();
    }
    
    public void ClearSelection()
    {
        _selectedSlot?.Diselect();
    }

    public void AddSpell(Spell spell, int slotIndex = 0)
    {
        _slots[slotIndex].Slot.Add(spell);
    }

    private void Awake()
    {
        foreach(var slot in _slots)
        {
            slot.Selected += OnSpellInventorySlotSelected;
            slot.Diselected += OnSpellInventorySlotDiselected;
        }
    }

    private void OnSpellInventorySlotSelected(SpellInventorySlot slot)
    {
        if(_selectedSlot == slot)
        {
            return;
        }
        
        _selectedSlot?.Diselect();
        _selectedSlot = slot;

        SlotSelected?.Invoke(_selectedSlot);

        
    }

    private void OnSpellInventorySlotDiselected(SpellInventorySlot slot)
    {
        if(_selectedSlot == slot)
        {
            _selectedSlot = null;

            SlotDiselected?.Invoke(slot);
        }
    }
}


