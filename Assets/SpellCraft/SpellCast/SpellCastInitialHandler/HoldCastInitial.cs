
using System;
using UnityEngine.InputSystem;

public class HoldCastInitial : SpellCastInitialHandler
{
    //При выборе слота ожидать кнопки каста
    public override event Action CastStarted;
    public override event Action Initialized;

    private AreaSpellSight _spellSight;
    private InputActionReference _castInput;

    public HoldCastInitial(AreaSpellSight spellSight, InputActionReference castInput)
    {
        _spellSight = spellSight;
        _castInput = castInput;
    }

    public override void InitialCast()
    {
        Enable();
        _spellSight.Enable();
    }
    public override void Disable()
    {
        _castInput.action.performed -= OnCastButton;
    }
    private void Enable()
    {
        _castInput.action.performed += OnCastButton;
    }

    private void OnCastButton(InputAction.CallbackContext c)
    {
        Disable();
        _spellSight.Disable();
        Initialized?.Invoke();
    }


}