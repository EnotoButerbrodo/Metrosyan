public abstract class EnergySpell : Spell
{
    protected float _damage;
    protected float _radius;
    protected float _range;

    public EnergySpell(float reloadTime, float damage, float radius, float range) : base(reloadTime)
    {
        _damage = damage;
        _radius = radius;
        _range = range;
    }
}

