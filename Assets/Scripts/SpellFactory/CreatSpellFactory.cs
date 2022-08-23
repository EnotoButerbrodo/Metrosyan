using UnityEngine;
public abstract class CreatSpellFactory : CreatSpellScriptableObject
{

    public Magic Get(ElementType statsMain, ElementType secondary)
    {
        Magic config = new Magic();

        config._spell = GetConfig(statsMain);
        config._extra = GetConfigExtra(secondary);
        config._spell.SpellObject.GetComponentInChildren<SkinnedMeshRenderer>().material = config._extra.Material;

        return config;
    }

    protected abstract SpellConfig GetConfig(ElementType _stats);
    protected abstract ExtraConfig GetConfigExtra(ElementType _stats);
}
