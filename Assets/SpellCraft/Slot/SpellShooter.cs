using System;
using UnityEngine;

public class SpellShooter : MonoBehaviour
{
    public Action SpellReloading;

    [SerializeField] private ReloadingSpell _spell;
    [SerializeField] private Timer _reloader;

    private bool _reloaded = true;
    private float _reloadTime;

    private void OnEnable()
    {
        _reloader.Finished += _spell.Reload;
    }

    private void OnDisable()
    {
        _reloader.Finished -= _spell.Reload;
    }
    public void Use(Ray direction, GameObject target = null)
    {
        if (_reloaded)
        {
            _reloaded = false;
            _spell.Use(direction, target);
            _reloader.StartTimer(_reloadTime);
        }
        else
        {
            SpellReloading?.Invoke();
        }
    }
}


