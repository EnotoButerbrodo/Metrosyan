using System;
using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "GolemCast", menuName = "Spell/GolemCast")]
public class GolemCast : Spell
{
    private Golem _prefab;
    private Attack _attack;

    private IEnumerable _startBuffs;

    public GolemCast(float reloadTime) : base(reloadTime)
    {
    }

    public override CastType CastType => CastType.Call;

    public void Init(Golem prefab, Attack attack, Core core)
    {
        _prefab = prefab;
        _attack = attack;
    }

    public void SetStartBuffs(IEnumerable spells)
    {
        _startBuffs = spells;
    }
    
    protected override void OnSpellUse(Ray direction, GameObject target)
    {
        var golem = GameObject.Instantiate(_prefab, direction.origin, Quaternion.Euler(direction.direction));
        golem.Init(_attack, _startBuffs);
    }
}
