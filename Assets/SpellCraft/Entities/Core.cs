
using UnityEngine;

[CreateAssetMenu(fileName = "Core", menuName = "SpellCraft/Core")]
public class Core : CraftEntity, IStorable
{
    Sprite IStorable.Sprite { get; set; }
    public string Id => nameof(Core);
}
