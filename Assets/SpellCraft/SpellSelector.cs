using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpellSelector : MonoBehaviour
{
    [SerializeField] private InputActionReference _FirstSlotInput;
    [SerializeField] private InputActionReference _SecondSlotInput;
    [SerializeField] private InputActionReference _ThirdSlotInput;
    [SerializeField] private InputActionReference _FourSlotInput;

    [SerializeField] private SpellInventory _spellInventory;

    private void OnEnable()
    {
        _FirstSlotInput.action.Enable();
        _FirstSlotInput.action.performed += SelectFirstSlot;

        _SecondSlotInput.action.Enable();
        _SecondSlotInput.action.performed += SelectSecondSlot;

        _ThirdSlotInput.action.Enable();
        _ThirdSlotInput.action.performed += SelectThirdSlot;

        _FourSlotInput.action.Enable();
        _FourSlotInput.action.performed += SelectFourSlot;
    }

    private void OnDisable()
    {

        _FirstSlotInput.action.Disable();
        _FirstSlotInput.action.performed -= SelectFirstSlot;

        _SecondSlotInput.action.Disable();
        _SecondSlotInput.action.performed -= SelectSecondSlot;

        _ThirdSlotInput.action.Disable();
        _ThirdSlotInput.action.performed -= SelectThirdSlot;

        _FourSlotInput.action.Disable();
        _FourSlotInput.action.performed -= SelectFourSlot;
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
}

