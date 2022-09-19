using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellTest : MonoBehaviour
{
    [SerializeField] private SpellInventory _inventory;
    private void Awake()
    {
        _inventory.AddSpell(new TestSpell(1), 0);
        _inventory.AddSpell(new TestHoldSpell(3), 1);
        _inventory.AddSpell(new TestDelaySpell(5), 2);
        _inventory.AddSpell(new Beam(3, 10, 10, 10), 3);
    }
}

public class TestSpell : Spell, IStorable
{
    public TestSpell(float reloadTime) : base(reloadTime)
    {
    }

    Sprite IStorable.Sprite { get; set; }
    public override CastType CastType => CastType.Call;
    public override CastInitialType CastInitialType => CastInitialType.Instantly;

    protected override void OnSpellUse(Ray direction, GameObject target = null)
    {
        Debug.Log($"Cast test spell {direction.origin}");
    }
}

public class TestHoldSpell : Spell
{
    public TestHoldSpell(float reloadTime) : base(reloadTime)
    {
    }
    public override CastType CastType => CastType.Shoot;

    public override CastInitialType CastInitialType => CastInitialType.Hold;

    protected override void OnSpellUse(Ray direction, GameObject target = null)
    {
        Debug.Log($"Cast hold test spell from {direction.origin} in direction {direction.direction}");
    }
}

public class TestDelaySpell : Spell
{
    public TestDelaySpell(float reloadTime) : base(reloadTime)
    {

    }
    public override CastType CastType => CastType.Call;

    public override CastInitialType CastInitialType => CastInitialType.Delay;

    protected override void OnSpellUse(Ray direction, GameObject target = null)
    {
        Debug.Log($"Cast delay test spell in {direction.origin}");
    }
}
