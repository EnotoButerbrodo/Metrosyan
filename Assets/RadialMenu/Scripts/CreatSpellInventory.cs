using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatSpellInventory : MonoBehaviour
{
    [SerializeField] private GameObject _prefabs;
    [SerializeField] private RectTransform ContentParent;
    [SerializeField] private RectTransform mouse;

    [SerializeField] private Sprite _sprite;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 5;i++)
        {
            GameObject spell = Instantiate(_prefabs,ContentParent);
            spell.GetComponent<SpellTesting>().Init(mouse,_sprite);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
