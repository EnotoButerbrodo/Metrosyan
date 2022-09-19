using UnityEngine;
using UnityEngine.InputSystem;

public class ShootSightMover : SpellSightMover
{
    protected override void OnMoveInput(InputAction.CallbackContext c)
    {
        if (_caster.TryGetSignPosition(_moveInput.action.ReadValue<Vector2>(), out Vector3 signPosition))
        {
            Ray moveRay = new Ray(transform.position, signPosition - transform.position );

            _spellSight.Move(moveRay);
        }
    }

    private void OnEnable()
    {
        EnableInput();
    }
}
