using UnityEngine;
using UnityEngine.InputSystem;

public abstract class SpellSight : MonoBehaviour, IInputLisener
{
    public abstract Vector3 GetPosition();

    [SerializeField] protected InputActionReference _inputAction;

    private bool _enabled = false;

    public void Enable()
    {
        _enabled = true;
        OnEnabled();

    }
    public void Disable()
    {
        _enabled = false;
        OnDisabled();
    }

    public void EnableInput()
    {
        _inputAction.action.Enable();
    }

    public void DisableInput()
    {
        _inputAction.action.Disable();
    }

    protected abstract void OnSightEnabled();
    protected abstract void OnEnabled();
    protected abstract void OnDisabled();

    private void LateUpdate()
    {
        if(_enabled == false)
        {
            return;
        }

        OnSightEnabled();
    }


}
