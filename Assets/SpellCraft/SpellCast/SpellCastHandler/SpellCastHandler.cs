using System;
using UnityEngine;

public abstract class SpellCastHandler 
{
    public abstract event Action Casted;

    protected Spell _spell;
    protected Timer _reloadTimer;
    protected Vector3 _castPosition;

    protected SpellCastHandler(Spell spell, Timer reloadTimer, Vector3 castPosition)
    {
        _spell = spell;
        _reloadTimer = reloadTimer;
        _castPosition = castPosition;
    }

    public abstract void Cast();

}



