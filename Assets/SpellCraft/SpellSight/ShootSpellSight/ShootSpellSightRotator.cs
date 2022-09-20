using UnityEngine;
using UnityEngine.InputSystem;

public class ShootSpellSightRotator : InputActionLisener
{
    [SerializeField] private ShootSpellSight _spellSight;
    [SerializeField] private SpellSightCaster _caster;
    protected override void OnInput(InputAction.CallbackContext c)
    {
        if(_caster.TryGetSignPosition(_inputAction.action.ReadValue<Vector2>(), 
                                      out Vector3 sightPosition))
        {
            _spellSight.Rotate(sightPosition);
        }
    }
}
