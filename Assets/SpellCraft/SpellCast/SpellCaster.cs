using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
public class SpellCaster : MonoBehaviour, IInputLisener
{
    public UnityEvent NotEnouthStamina;
    [SerializeField] private SpellSight _spellSign;
    [SerializeField] private InputActionReference _castInput;
    [SerializeField] private SpellInventory _spellInventory;

    private SpellCastInitialHandler GetInitHandler(SpellInventorySlot slot)
        => slot.Slot.CurrentItem.CastInitialType switch
        {
            CastInitialType.Instantly => new InstantCastInitial(),
            CastInitialType.Delay => new DelayCastInitial(1, slot.SlotReloadTimer, _spellSign),
            CastInitialType.Hold => new HoldCastInitial(_spellSign, _castInput),
            _ => new InstantCastInitial(),
        };
    public void Cast(Timer reloadTimer, Spell spell, Ray direction, GameObject target = null)
    {
        spell.Use(reloadTimer, direction, target);
    }

    public void EnableInput()
    {
        _castInput.action.Enable();
        _spellSign.EnableInput();
    }

    public void DisableInput()
    {
        _castInput.action.Disable();
        _spellSign.DisableInput();
    }

    private void OnSlotSelected(SpellInventorySlot slot)
    {

        
    }

    private void OnSlotDiselected(SpellInventorySlot slot)
    {
        _spellSign.Hide();
    }

    private void CastHandler()
    {
        SpellInventorySlot slot = _spellInventory.SelectedSlot;
        Timer reloadTimer = _spellInventory.SelectedSlot.SlotReloadTimer;
        Spell spell = slot.Slot.CurrentItem;

        switch (spell.CastType)
        {
            case CastType.Call:
                Cast(reloadTimer, spell, new Ray(_spellSign.Position, Vector3.zero));
                break;
            case CastType.Shoot:
                Cast(reloadTimer, spell, new Ray(transform.position, _spellSign.transform.position - transform.position));
                break;
            case CastType.Target:
                Cast(reloadTimer, spell, new Ray(transform.position, Vector3.zero), gameObject);
                break;
            default:
                Cast(reloadTimer, spell, new Ray(transform.position, _spellSign.transform.position - transform.position));
                break;
        }
        slot.Diselect();

    }
    private void OnCastPressed(InputAction.CallbackContext context)
    {

        if (_spellInventory.SelectedSlot?.Slot.CurrentItem is null)
        {
            return;
        }

        CastHandler();

        _spellSign.Hide();
    }

    private void OnEnable()
    {
        EnableInput();
        _castInput.action.performed += OnCastPressed;
        _spellInventory.SelectedSlotReloading += () => { UnityEngine.Debug.Log("Слот перезаряжается"); };

    }
    private void OnDisable()
    {
        DisableInput();
        _castInput.action.performed -= OnCastPressed;

    }

}
