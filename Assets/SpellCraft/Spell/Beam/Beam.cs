using UnityEngine;

public class Beam : EnergySpell
{
    public override CastType CastType => CastType.Shoot;
    public override CastInitialType CastInitialType => CastInitialType.Delay;

    public Beam(float reloadTime, float damage, float radius, float range) : base(reloadTime, damage, radius, range)
    {
    }

    protected override void OnSpellUse(Ray direction, GameObject target = null)
    {
        Debug.Log("I shoot beam");
    }
}

