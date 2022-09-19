using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
public class SpellCaster : MonoBehaviour, IInputLisener
{
    public UnityEvent NotEnouthStamina;
    [SerializeField] private SpellSighManager _spellSign;
    [SerializeField] private InputActionReference _castInput;
    [SerializeField] private SpellInventory _spellInventory;
    [SerializeField] private SpellSelector _spellSelector;

    private SpellCastInitialHandler _castInitialHadler;

    private SpellCastInitialHandler GetInitHandler(SpellInventorySlot slot)
        => slot.Slot.CurrentItem.CastInitialType switch
        {
            CastInitialType.Instantly => new InstantCastInitial(),
            CastInitialType.Delay => new DelayCastInitial(3, slot.CastTimer, _spellSign),
            CastInitialType.Hold => new HoldCastInitial(_spellSign, _castInput),
            _ => new InstantCastInitial(),
        };

    private Ray GetCastRay(CastType type)
       => type switch
       {
           CastType.Call => new Ray(_spellSign.Position, Vector3.zero),
           CastType.Shoot => new Ray(transform.position, _spellSign.transform.position - transform.position),
           CastType.Target => new Ray(transform.position, Vector3.zero),
           _ => new Ray(transform.position, Vector3.zero),
       };

    private GameObject GetCastTarget(CastType type)
        => type switch
        {
            CastType.Target => gameObject,
            _ => null,
        };


    private void CastSpell()
    {
        SpellInventorySlot slot = _spellInventory.SelectedSlot;
        Timer reloadTimer = _spellInventory.SelectedSlot.ReloadTimer;
        Spell spell = slot.Slot.CurrentItem;
        CastType castType = spell.CastType;

        spell.Use(reloadTimer, GetCastRay(castType), GetCastTarget(castType));

        slot.Diselect();
        _spellSign.Hide();
        _spellSelector.EnableInput();
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
        if (slot.IsEmpty)
        {
            return;
        }

        _castInitialHadler = GetInitHandler(slot);
        _castInitialHadler.Initialized += CastSpell;

        _spellSelector.DisableInput();
        _castInitialHadler.InitialCast();

    }
    private void OnEnable()
    {
        EnableInput();
        _spellInventory.SlotSelected += OnSlotSelected;
        _spellInventory.SelectedSlotReloading += () => { UnityEngine.Debug.Log("Слот перезаряжается"); };

    }
    private void OnDisable()
    {
        DisableInput();
    }

}
