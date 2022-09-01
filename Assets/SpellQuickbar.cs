using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpellQuickbar : MonoBehaviour
{
    [SerializeField] private List<QuickbarSlot> _slots;

    [SerializeField] private QuickbarSlot _selectedSlot;

    public Spell SelectedSpell => _selectedSlot?.SpellSlot.CurrentItem ?? null;


    private void OnEnable()
    {
        foreach (var slot in _slots)
        {
            slot.Selected += OnSlotSelected;
        }

        if (_slots.Count > 0)
        {
            _slots[0].Select();
        }
    }

    private void OnDisable()
    {
        foreach (var slot in _slots)
        {
            slot.Selected -= OnSlotSelected;
        }
    }

    private void OnSlotSelected(QuickbarSlot slot)
    {
        if(slot == _selectedSlot)
        {
            return;
        }
        _selectedSlot?.Diselect();
        _selectedSlot = slot;
    }

}


