using UnityEngine;

public class ItemMagic
{
    public string Name;
    public string Specifications;
    public Sprite Sprite;

    public ItemMagic(string name,string specifications, Sprite sprite)
    {
        Name = name;
        Specifications = specifications;
        Sprite = sprite;
    }
}
