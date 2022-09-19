public abstract class EnergySpell : Spell
{
    protected float _damage;
    protected float _radius;
    protected float _castRange;

    public EnergySpell(float reloadTime, float damage, float radius, float castRange) : base(reloadTime)
    {
        _damage = damage;
        _radius = radius;
        _castRange = castRange;
    }
}

