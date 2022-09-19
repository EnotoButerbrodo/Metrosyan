using UnityEngine;
using UnityEngine.InputSystem;
public abstract class SpellSightMover : MonoBehaviour , IInputLisener
{
    [SerializeField] protected SpellSight _spellSight;
    [SerializeField] protected InputActionReference _moveInput;
    [SerializeField] protected SpellSighCaster _caster;

    public void EnableInput()
    {
        _moveInput.action.Enable();
        _moveInput.action.performed += OnMoveInput;
    }
    public void DisableInput()
    {
        _moveInput.action.Disable();
        _moveInput.action.performed -= OnMoveInput;
    }

    protected abstract void OnMoveInput(InputAction.CallbackContext c);

    
}
