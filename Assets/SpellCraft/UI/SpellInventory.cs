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
    public Spell SelectedSpell => _selectedSlot.Slot.CurrentItem ?? null;

    [SerializeField] private List<SpellInventorySlot> _slots;

    [SerializeField] private SpellInventorySlot _selectedSlot;

    
    public void AddSpell(Spell spell)
    {
        if(_selectedSlot is null)
        {
            _selectedSlot = _slots[0];
        }
        _selectedSlot.Slot.Add(spell);
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


