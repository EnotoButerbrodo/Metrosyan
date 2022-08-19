using System;
using UnityEditor;
using UnityEngine;

[Serializable]
public class EntityStats 
{
    [SerializeField] private float _damage;
    [SerializeField] private ElementType _type;
    [SerializeField] private string _name;
    [SerializeField] private GameObject _prefabs;

    public float Damage => _damage;
    public ElementType Type => _type;
    public string Name => _name;
    public GameObject Prefabs => _prefabs;
    
}
