using UnityEngine;

[CreateAssetMenu(fileName = "SpritesStorage")]
public class SpritesStorage : ScriptableObject
{
    [SerializeField] private Sprite _defaultSprite;
    [SerializeField] private Sprite _coreSprite;
    [SerializeField] private Sprite _spellSprite;
    [SerializeField] private Sprite _testSpellSprite;
    public Sprite Get(string id) =>
        id switch
        {
            nameof(Core) => _coreSprite,
            nameof(Spell) => _spellSprite,
            nameof(TestSpell) => _testSpellSprite,
            _ => _defaultSprite,
        };
}

public interface ISpriteProvider
{
    public Sprite Get();
}