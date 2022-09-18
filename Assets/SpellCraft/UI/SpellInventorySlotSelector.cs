using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(SpellInventorySlotLink))]
public class SpellInventorySlotSelector : MonoBehaviour
{
    private SpellInventorySlotLink _link;

    private void Awake()
    {
        _link = GetComponent<SpellInventorySlotLink>();
    }
    private void OnEnable()
    {
        _link.SpellInventorySlot.Selected += Select;
        _link.SpellInventorySlot.Diselected += Diselect;
    }

    private void OnDisable()
    {
        _link.SpellInventorySlot.Selected -= Select;
        _link.SpellInventorySlot.Diselected -= Diselect;

    }
    public void Select(SpellInventorySlot slot)
    {
        _link.SelectImage.enabled = true;
    }

    public void Diselect(SpellInventorySlot slot)
    {
        _link.SelectImage.enabled = false;
    }

}
