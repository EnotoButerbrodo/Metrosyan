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
    public abstract CastTime CastTime { get; }
    public bool Reloading => _reloading;
    public float ReloadTime => _reloadTime;
    public float CastRange => _castRange;

    private float _damage;
    private float _castRange;

    Sprite IStorable.Sprite { get; set; }

    private float _reloadTime;
    private bool _reloading;
    private float reloadTime;

    public Spell(float reloadTime = 1f, float castRange = 1f, float damage = 1f)
    {
        _reloadTime = reloadTime;
        _castRange = castRange;
        _damage = damage;
    }

    protected Spell(float reloadTime)
    {
        this.reloadTime = reloadTime;
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

