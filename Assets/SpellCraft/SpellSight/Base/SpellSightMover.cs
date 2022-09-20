using UnityEngine;
using UnityEngine.InputSystem;
public class SpellSightMover : InputActionLisener
{
    [SerializeField] protected SpellSight _spellSight;
    [SerializeField] protected SpellSightCaster _caster;

    protected override void OnInput(InputAction.CallbackContext c)
    {
        if(_caster.TryGetSignPosition(_inputAction.action.ReadValue<Vector2>(),
                                        out Vector3 sightPosition))
        {
            _spellSight.Move(sightPosition);
        }
    }
}
