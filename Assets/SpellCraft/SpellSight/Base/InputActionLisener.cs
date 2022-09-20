using UnityEngine;
using UnityEngine.InputSystem;

public abstract class InputActionLisener : MonoBehaviour, IInputLisener
{
    [SerializeField] protected InputActionReference _inputAction;

    public void EnableInput()
    {
        _inputAction.action.Enable();
        _inputAction.action.performed += OnInput;
    }
    public void DisableInput()
    {
        _inputAction.action.Disable();
        _inputAction.action.performed -= OnInput;
    }

    protected abstract void OnInput(InputAction.CallbackContext c);
}
