using UnityEngine;
[CreateAssetMenu(fileName = "Main", menuName = "Variety/Spell")]
public class SpellConfig : Entity
{
    [SerializeField] private GameObject _spellObject;
    public GameObject SpellObject => _spellObject;
}
