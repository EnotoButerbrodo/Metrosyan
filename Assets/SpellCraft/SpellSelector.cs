using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpellSelector : MonoBehaviour, IInputLisener
{
    [SerializeField] private InputActionReference _FirstSlotInput;
    [SerializeField] private InputActionReference _SecondSlotInput;
    [SerializeField] private InputActionReference _ThirdSlotInput;
    [SerializeField] private InputActionReference _FourSlotInput;
    [SerializeField] private InputActionReference _CancelInput;

    [SerializeField] private SpellInventory _spellInventory;

    public void EnableInput()
    {
        _FirstSlotInput.action.Enable();
        _FirstSlotInput.action.performed += SelectFirstSlot;

        _SecondSlotInput.action.Enable();
        _SecondSlotInput.action.performed += SelectSecondSlot;

        _ThirdSlotInput.action.Enable();
        _ThirdSlotInput.action.performed += SelectThirdSlot;

        _FourSlotInput.action.Enable();
        _FourSlotInput.action.performed += SelectFourSlot;

        _CancelInput.action.Enable();
        _CancelInput.action.performed += OnCancelButton;
    }

    public void DisableInput()
    {
        _FirstSlotInput.action.Disable();
        _FirstSlotInput.action.performed -= SelectFirstSlot;

        _SecondSlotInput.action.Disable();
        _SecondSlotInput.action.performed -= SelectSecondSlot;

        _ThirdSlotInput.action.Disable();
        _ThirdSlotInput.action.performed -= SelectThirdSlot;

        _FourSlotInput.action.Disable();
        _FourSlotInput.action.performed -= SelectFourSlot;

        _CancelInput.action.Disable();
        _CancelInput.action.performed -= OnCancelButton;
    }

    private void OnEnable()
    {
        EnableInput();    
    }

    private void OnDisable()
    {
        DisableInput();
    }

    private void SelectFirstSlot(InputAction.CallbackContext c)
    {
        _spellInventory.SelectSlot(0);
    }

    private void SelectSecondSlot(InputAction.CallbackContext c)
    {
        _spellInventory.SelectSlot(1);
    }

    private void SelectThirdSlot(InputAction.CallbackContext c)
    {
        _spellInventory.SelectSlot(2);
    }

    private void SelectFourSlot(InputAction.CallbackContext c)
    {
        _spellInventory.SelectSlot(3);
    }

    private void OnCancelButton(InputAction.CallbackContext c)
    {
        _spellInventory.ClearSelection();
    }


}

