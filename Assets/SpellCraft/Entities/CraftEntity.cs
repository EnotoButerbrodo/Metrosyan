using UnityEngine;

public abstract class CraftEntity : ScriptableObject, IStorable
{                                                         
    [SerializeField] private EntityStats _stats;
    [SerializeField] private Color _color;
    [SerializeField] private Sprite _sprite;

    public Color Color => _color;
    public EntityStats Stats => _stats;
    Sprite IStorable.Sprite
    {
        get
        {
            return _sprite;
        }
        set
        {
            _sprite = value;
        }
    }
}
