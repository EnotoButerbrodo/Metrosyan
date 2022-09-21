using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.Rendering.DebugUI.Table;

public class SpellSightMover : InputActionLisener
{
    [SerializeField] protected SpellSight _spellSight;
    [SerializeField] protected SpellSightCaster _caster;

    protected override void OnInput(InputAction.CallbackContext c)
    {
        if(_caster.TryGetSignPosition(_inputAction.action.ReadValue<Vector2>(),
                                        out Vector3 sightPosition,
                                        out RaycastHit hit))
        {
            _spellSight.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
   
        }
    }

    
}
