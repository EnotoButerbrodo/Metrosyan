using System;
using UnityEngine;

public class MagicBallCastFactory : SpellFactory
{
    [SerializeField] private MagicBallCast _magicBallCastPrefab;
    [SerializeField] private MagicBallFactoryPrefabs _prefabs;

    public override Spell Get(Core core)
    {
        MagicBallCast spell = new MagicBallCast();
        MagicBall magicBall = _prefabs.GetPrefab(core);

        spell.Init(magicBall, Convert.ToInt32(core.Stats.Damage), core);

        return spell;
    }

    
}
