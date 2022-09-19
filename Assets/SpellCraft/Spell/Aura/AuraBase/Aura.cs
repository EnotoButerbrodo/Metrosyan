using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Aura", menuName = "SpellCraft/Aura")]
public class Aura : Spell
{
    public event Action Enabled;
    public event Action Disabled;

    private AuraConfig _auraConfig;

    private Attack _auraAttack;

    public Aura(float reloadTime) : base(reloadTime)
    {
    }

    public override CastType CastType => CastType.Target;

    public override CastInitialType CastInitialType => CastInitialType.Instantly;

    public void Init(Attack auraAttack, AuraConfig auraConfig)
    {
        _auraAttack = auraAttack;
        _auraConfig = auraConfig;
    } 

    protected override void OnSpellUse(Ray direction, GameObject target)
    {
        var auraEffect = target.AddComponent<AuraEffect>();
        auraEffect.Init(_auraAttack, _auraConfig);
        auraEffect.EnableAura();
    }

}
