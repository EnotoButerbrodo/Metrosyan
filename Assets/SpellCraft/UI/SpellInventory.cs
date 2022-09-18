using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class SpellInventory : MonoBehaviour
{
    public event Action SpellSelected;
    public event Action SpelDiselected;

    public bool IsSpellSelected => _selectedSlot != null;
    public SpellInventorySlot SelectedSlot => _selectedSlot ?? null;

    public int SlotsCount => _slots.Count;
    [SerializeField] private List<SpellInventorySlot> _slots;

    [SerializeField] private SpellInventorySlot _selectedSlot;

    
    public void AddSpell(Spell spell, int slotIndex = 0)
    {
        _slots[slotIndex].Slot.Add(spell);
    }

    private void Awake()
    {
        foreach(var slot in _slots)
        {
            slot.Selected += OnSlotSelected;
            slot.Diselected += OnSlotDiselected;
        }
    }

    private void OnSlotSelected(SpellInventorySlot slot)
    {
        if(_selectedSlot == slot)
        {
            _selectedSlot?.Diselect();
            _selectedSlot = null;
        }
        else
        {
            _selectedSlot?.Diselect();
            _selectedSlot = slot;
        }
    }

    private void OnSlotDiselected(SpellInventorySlot slot)
    {
        if(_selectedSlot == slot)
        {
            _selectedSlot = null;
        }
    }
}


