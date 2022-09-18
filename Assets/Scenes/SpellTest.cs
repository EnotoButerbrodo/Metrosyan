using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellTest : MonoBehaviour
{
    [SerializeField] private SpellInventory _inventory;
    private void Awake()
    {
        for(int i = 0; i< _inventory.SlotsCount; i++)
        {
            Spell testSpell = new TestSpell(i + 1);
            _inventory.AddSpell(testSpell, i);
        }
    }
}

public class TestSpell : Spell, IStorable
{
    public TestSpell(float reloadTime) : base(reloadTime)
    {
    }
    Sprite IStorable.Sprite { get; set; }
    public override CastType CastType => CastType.Shoot;

    protected override void OnSpellUse(Ray direction, GameObject target = null)
    {
        Debug.Log($"Cast test spell {direction.origin}");
    }
}