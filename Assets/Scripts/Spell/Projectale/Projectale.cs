using UnityEngine;

[System.Serializable]
public class Projectale
{
    public float Damage;
    public ElementType Type;
    public string Appearance;

    public GameObject ViewObject;

    public Projectale(float damage, ElementType type, string appearance, GameObject viewObject)
    {
        Damage = damage;
        Type = type;
        Appearance = appearance;
        ViewObject = viewObject;
    }
}
