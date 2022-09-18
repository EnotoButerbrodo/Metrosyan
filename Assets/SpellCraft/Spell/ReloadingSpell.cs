using System.Collections;
using UnityEngine;
public class ReloadingSpell : Spell
{
    public override CastType CastType => _spell.CastType;

    public bool Reloading => _reloading;

    private Spell _spell;
    private float _reloadTime;
    private bool _reloading;
    public ReloadingSpell(Spell spell, float reloadTime)
    {
        _spell = spell;
        _reloadTime = reloadTime;
    }
    public void Reload()
    {
        _reloading = true;
    }
    public override void Use(Ray direction, GameObject target = null)
    {
        if (_reloading)
        {
            return;
        }

        _spell.Use(direction, target);
        _reloading = true;
    }

}
