using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class SpellCaster : MonoBehaviour, IInputLisener
{
    public UnityEvent NotEnouthStamina;
    [SerializeField] private SpellSight _spellSign;
    [SerializeField] private InputActionReference _castInput;
    [SerializeField] private SpellInventory _spellInventory;

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
        _spellSign.Show();
    }

    private void OnSlotDiselected(SpellInventorySlot slot)
    {
        _spellSign.Hide();
    }

    private void OnCastPressed(InputAction.CallbackContext context)
    {

        if (_spellInventory.SelectedSlot?.Slot.CurrentItem is null)
        {
            return;
        }

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

        _spellSign.Hide();
    }

    private void OnEnable()
    {
        EnableInput();
        _castInput.action.performed += OnCastPressed;
        _spellInventory.SlotSelected += _spellSign.Show;
        _spellInventory.SlotDiselected += _spellSign.Hide;

    }
    private void OnDisable()
    {
        DisableInput();
        _castInput.action.performed -= OnCastPressed;
        _spellInventory.SlotSelected -= _spellSign.Show;
        _spellInventory.SlotDiselected -= _spellSign.Hide;

    }

}

