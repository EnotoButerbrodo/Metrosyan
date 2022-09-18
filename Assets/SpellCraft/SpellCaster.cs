using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class SpellCaster : MonoBehaviour, IInputLisener
{
    public UnityEvent NotEnouthStamina;
    [SerializeField] private SpellSight _spellSign;
    [SerializeField] private InputActionReference _castInput;
    [SerializeField] private SpellInventory _spellInventory;

    public void Cast(Timer reloadTimer, Spell spell, Ray direction, GameObject target = null)
    {
        spell.Use(reloadTimer, direction, target);
    }

    public void EnableInput()
    {
        _castInput.action.Enable();
        _spellSign.EnableInput();
    }

    public void DisableInput()
    {
        _castInput.action.Disable();
        _spellSign.DisableInput();
    }

    private void OnSlotSelected(SpellInventorySlot slot)
    {

        //Смотрим на время каста
        switch (slot.Slot.CurrentItem.CastTime)
        {
            case CastTime.Instantly:
                //Скастовать заклинание моментально
                CastHandler();
                break;
            case CastTime.Delay:
                /*
                 * Активировать таймер. Время задается исходя из заклинания
                 * После таймера выстрелить по позиции курсора
                 */
                //Запустить корутину каста
                break;
            case CastTime.Hold:
                /*
                 * Активировать прицел
                 * Ожидать кнопку каста заклинания.
                 */
                //Запустить коротину ожидания кнопки?
                break;
        }
        _spellSign.Show();
    }

    private void OnSlotDiselected(SpellInventorySlot slot)
    {
        _spellSign.Hide();
    }

    private void CastHandler()
    {
        SpellInventorySlot slot = _spellInventory.SelectedSlot;
        Timer reloadTimer = _spellInventory.SelectedSlot.SlotReloadTimer;
        Spell spell = slot.Slot.CurrentItem;

        switch (spell.CastType)
        {
            case CastType.Call:
                Cast(reloadTimer, spell, new Ray(_spellSign.Position, Vector3.zero));
                break;
            case CastType.Shoot:
                Cast(reloadTimer, spell, new Ray(transform.position, _spellSign.transform.position - transform.position));
                break;
            case CastType.Target:
                Cast(reloadTimer, spell, new Ray(transform.position, Vector3.zero), gameObject);
                break;
            default:
                Cast(reloadTimer, spell, new Ray(transform.position, _spellSign.transform.position - transform.position));
                break;
        }
        slot.Diselect();

    }
    private void OnCastPressed(InputAction.CallbackContext context)
    {

        if (_spellInventory.SelectedSlot?.Slot.CurrentItem is null)
        {
            return;
        }

        CastHandler();

        _spellSign.Hide();
    }

    private void OnEnable()
    {
        EnableInput();
        _castInput.action.performed += OnCastPressed;
        _spellInventory.SelectedSlotReloading += () => { UnityEngine.Debug.Log("Слот перезаряжается"); };

    }
    private void OnDisable()
    {
        DisableInput();
        _castInput.action.performed -= OnCastPressed;

    }

}

//public interface ICastTimeStraregy
//{
//    void Cast(Timer timer, Spell spell);
//}

//public class InstantCastStrategy : ICastTimeStraregy
//{
//    private Vector3 _castPosition;
//    private Vector3 _spellSightPosition;

//    public InstantCastStrategy(Vector3 castPosition, Vector3 spellSightPosition)
//    {
//        _castPosition = castPosition;
//        _spellSightPosition = spellSightPosition;
//    }

//    public void Cast(Timer timer, Spell spell)
//    {
//        spell.Use(timer, castTypeStrategy.GetDirection(), castTypeStrategy.GetTarget());
//    }
//}

//public interface ICastTypeStrategy
//{
//    public Ray GetDirection();
//    public GameObject GetTarget();
//}

//public class CallCastStrategy : ICastTypeStrategy
//{
//    private SpellSight _sight;

//    public CallCastStrategy(SpellSight sight)
//    {
//        _sight = sight;
//    }

//    public Ray GetDirection() =>
//        new Ray(_sight.Position, Vector3.zero);


//    public GameObject GetTarget() => null;
//}