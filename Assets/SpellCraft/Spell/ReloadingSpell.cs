using System;
using System.Collections;
using UnityEngine;

public class ReloadingSpell : Spell
{
    public Action SpellReloading;
    protected float _reloadTime;
    
    private Spell _spell;

    private bool _reloaded = true;

    private ReloadTimer _reloader;
    public ReloadingSpell(Spell spell, float reloadTime, ReloadTimer reloader)
    {
        _spell = spell;
        _reloadTime = reloadTime;
        _reloader = reloader;

        _reloader.Finished += OnSpellReloaded;
    }

    ~ReloadingSpell()
    {
        _reloader.Finished -= OnSpellReloaded;
    }

    public override CastType CastType => _spell.CastType;

    public override void Use(Ray direction, GameObject target = null)
    {
        if (_reloaded)
        {
            _reloaded = false;
            _spell.Use(direction, target);
            _reloader.Start(_reloadTime);
        }
        else
        {
            SpellReloading?.Invoke();
        }
    }
    
    private void OnSpellReloaded()
    {
        _reloaded = true;
    }
    
}
