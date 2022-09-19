using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(SpellInventorySlotLink))]
public class SpellInventorySlotSelector : MonoBehaviour
{
    [SerializeField] private Image _selectImage;
    [SerializeField] private bool _reversed;

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
        _selectImage.enabled = true;
    }

    public void Diselect(SpellInventorySlot slot)
    {
        _selectImage.enabled = false;
    }

}
