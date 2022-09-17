using System;
using UnityEngine;

public class SpellShooter : MonoBehaviour
{
    public Action SpellReloading;

    [SerializeField] private Spell _spell;
    [SerializeField] private ReloadTimer _reloader;

    private bool _reloaded = true;
    private float _reloadTime;
    public void Use(Ray direction, GameObject target = null)
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
}


