using System;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Базовый класс для заклинаний
/// </summary>

public abstract class Spell : IStorable
{
    public Action<Spell> Used;
    public abstract CastType CastType { get; }
    public bool Reloading => _reloading;
    public float ReloadTime => _reloadTime;

    private float _reloadTime;
    private bool _reloading;
    public Sprite Sprite => null;

    public Spell(float reloadTime)
    {
        _reloadTime = reloadTime;
    }
    private void Reload()
    {
        _reloading = false;
    }
    public void Use(Timer reloadTimer, Ray direction, GameObject target = null)
    {
        if (_reloading)
        {
            return;
        }
        OnSpellUse(direction, target);
        _reloading = true;

        reloadTimer.Finished += Reload;
        reloadTimer.StartTimer(_reloadTime);
    }

    

    protected abstract void OnSpellUse(Ray direction, GameObject target = null);
}
