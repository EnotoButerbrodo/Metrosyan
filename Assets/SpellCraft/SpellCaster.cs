using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class SpellCaster : MonoBehaviour, IInputLisener
{
    public UnityEvent NotEnouthStamina;
    [SerializeField] private SpellSight _spellSign;
    [SerializeField] private InputActionReference _castInput;
    [SerializeField] private SpellInventory _spellQuickbar;
    [SerializeField] private Stamina _stamina;

    public void Cast(Spell spell, Ray direction, GameObject target = null)
    {
        float neededStamina = 1;
        if (spell is GolemCast)
        {
            neededStamina = _stamina.MaxStamina;
        }

        if (_stamina.TrySpend(neededStamina))
        {
            spell.Use(direction, target);
        }
        else
        {
            NotEnouthStamina?.Invoke();
        }
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

        if (_spellQuickbar.SelectedSpell is null)
        {
            return;
        }

        var spell = _spellQuickbar.SelectedSpell;

        switch (spell.CastType)
        {
            case CastType.Call:
                Cast(spell, new Ray(_spellSign.Position, Vector3.zero));
                break;
            case CastType.Shoot:
                Cast(spell, new Ray(transform.position, _spellSign.transform.position - transform.position));
                break;
            case CastType.Target:
                Cast(spell, new Ray(transform.position, Vector3.zero), gameObject);
                break;
            default:
                Cast(spell, new Ray(transform.position, _spellSign.transform.position - transform.position));
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

