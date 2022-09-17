using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SpellInventorySlotSelector : MonoBehaviour
{
    [SerializeField] private SpellInventorySlot _slot;
    [SerializeField] private Image _selectImage;


    private void OnEnable()
    {
        _slot.Selected += Select;
        _slot.Diselected += Diselect;
    }

    private void OnDisable()
    {
        _slot.Selected -= Select;
        _slot.Diselected -= Diselect;

    }
    public void Select(SpellInventorySlot slot)
    {
        _selectImage.enabled = true;
    }

    public void Diselect(SpellInventorySlot slot)
    {
        _selectImage.enabled = false;
    }

}
