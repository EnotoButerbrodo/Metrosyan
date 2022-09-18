using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellTest : MonoBehaviour
{
    [SerializeField] private SpellInventory _inventory;
    private void Awake()
    {
        Spell testSpell = new TestSpell(1);
        _inventory.AddSpell(testSpell);
    }
}

public class TestSpell : Spell
{
    public TestSpell(float reloadTime) : base(reloadTime)
    {
    }

    public override CastType CastType => CastType.Shoot;

    protected override void OnSpellUse(Ray direction, GameObject target = null)
    {
        Debug.Log("Cast test spell");
    }
}