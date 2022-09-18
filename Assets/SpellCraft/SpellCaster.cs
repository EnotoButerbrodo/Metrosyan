using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class SpellCaster : MonoBehaviour, IInputLisener
{
    public UnityEvent NotEnouthStamina;
    [SerializeField] private SpellSight _spellSign;
    [SerializeField] private InputActionReference _castInput;
    [SerializeField] private SpellInventory _spellQuickbar;

    public void Cast(Timer reloadTimer, Spell spell, Ray direction, GameObject target = null)
    {
        spell.Use(reloadTimer, direction, target);
    }

    private void Awake()
    { 
        _spellSign.Hide();
    }
      
    private void OnEnable()
    {
        EnableInput();
        _castInput.action.performed += OnCastPressed;
        _spellQuickbar.SpellSelected += _spellSign.Show;
        _spellQuickbar.SpelDiselected += _spellSign.Hide;

    }
    private void OnDisable()
    {
        DisableInput();
        _castInput.action.performed -= OnCastPressed;
        _spellQuickbar.SpellSelected -= _spellSign.Show;
        _spellQuickbar.SpelDiselected -= _spellSign.Hide;

    }



    private void OnCastPressed(InputAction.CallbackContext context)
    {

        if (_spellQuickbar.SelectedSlot?.Slot.CurrentItem is null)
        {
            return;
        }

        SpellInventorySlot slot = _spellQuickbar.SelectedSlot;
        Timer reloadTimer = _spellQuickbar.SelectedSlot.SlotTimer;
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
}

