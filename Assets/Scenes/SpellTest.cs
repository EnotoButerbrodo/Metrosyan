using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellTest : MonoBehaviour
{
    [SerializeField] private SpellSlot _slot;
    [SerializeField] private ReloadTimer _spellReloader;
    private void Awake()
    {
        Spell testSpell = new TestSpell();
        ReloadingSpell reloadingSpell = new ReloadingSpell(testSpell, 1, _spellReloader);
        _slot.Add(reloadingSpell);
    }
}

public class TestSpell : Spell
{
    public override CastType CastType => CastType.Shoot;

    public override void Use(Ray direction, GameObject target = null)
    {
        Debug.Log("Test shoot");
    }
}