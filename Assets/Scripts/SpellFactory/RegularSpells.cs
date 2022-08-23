using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularSpells : CreatSpellFactory
{

    [SerializeField] private SpellConfig _hpGolem, _rpgGolem, _noneGolem;
    [SerializeField] private ExtraConfig _water, _fire, _miron;
    protected override SpellConfig GetConfig(ElementType _stats)
    {
        switch (_stats)
        {
            case ElementType.Fire:
                return _hpGolem;
            case ElementType.Ice:
                return _rpgGolem;
        }
        Debug.LogError($"No Configuration: {_stats}");
        return _noneGolem;
    }

    protected override ExtraConfig GetConfigExtra(ElementType _stats)
    {
       
        switch (_stats)
        {
            case ElementType.Fire:
                return _fire;
            case ElementType.Ice:
                return _water;
        }
        return _miron;
    }
}
