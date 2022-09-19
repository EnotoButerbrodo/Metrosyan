using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class AreaSpellSightMover : SpellSightMover
{
    protected override void OnMoveInput(InputAction.CallbackContext c)
    {
        if(_caster.TryGetSignPosition(_moveInput.action.ReadValue<Vector2>(), out Vector3 signPosition))
        {
            Ray moveRay = new Ray(signPosition, Vector3.zero);

            _spellSight.Move(moveRay);
        }
    }
}
