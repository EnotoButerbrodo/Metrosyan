using System;
using UnityEngine;

[RequireComponent(typeof(SpellInventorySlotLink))]
public class SpellShooter : MonoBehaviour
{
    public Action SpellReloading;

    private SpellInventorySlotLink _link;

    private Spell _spell;

    private bool _reloaded = true;

    private void Awake()
    {
        _link = GetComponent<SpellInventorySlotLink>();

    }



    public void OnSpellAdded(Spell spell)
    {
        _spell = spell;
    }

    private void OnSpellRemoved(Spell spell)
    {
        _spell = null;        
    }

  

    private void OnEnable()
    {
        _link.ReloadTimer.Finished += _spell.Reload;
        _link.SpellSlot.Added += OnSpellAdded;
        _link.SpellSlot.Removing += OnSpellRemoved;
    }

    private void OnDisable()
    {
        _link.ReloadTimer.Finished -= _spell.Reload;
        _link.SpellSlot.Added -= OnSpellAdded;
        _link.SpellSlot.Removing -= OnSpellRemoved;
    }
    public void Use(Ray direction, GameObject target = null)
    {
        if (_reloaded)
        {
            _reloaded = false;
            _spell.Use(direction, target);
            _link.ReloadTimer.StartTimer(_spell.ReloadTime);
        }
        else
        {
            SpellReloading?.Invoke();
        }
    }
}


