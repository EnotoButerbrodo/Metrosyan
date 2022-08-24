using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private List<Magic> _uiSlots = new List<Magic>();
    [SerializeField] private Button _spellButton;
    [SerializeField] private RectTransform _contentParent;
    [SerializeField] private Transform _spawnDot;

    public static InventoryUI _instance;
    public Inventory _inventory;
    void Start()
    {
        _instance = this;
        _inventory.OnAddSlot += AddItemSlots;
    }

    private void OnDisable()
    {
        _inventory.OnAddSlot -= AddItemSlots;
    }
    private void AddItemSlots(Magic spell)
    {
        _uiSlots.Add(spell);
        var buttonSpell = Instantiate(_spellButton,_contentParent);
        buttonSpell.GetComponentInChildren<TextMeshProUGUI>().text = 
            String.Format("Type main core = {0}, extra = {1}",spell._spell.Stats.Type, spell._extra.Type);
        buttonSpell.GetComponent<Image>().sprite = spell._spell.Sprite;
        buttonSpell.onClick.AddListener (delegate {InformationForSpell(_uiSlots.Count-1); } ) ;
        
    }

    private void InformationForSpell(int i)
    {
        Debug.Log("Номер магии = " + i);
        GameObject test = Instantiate(_uiSlots[i]._spell.SpellObject,_spawnDot.position,_spawnDot.rotation);
        Destroy(test,3f);
    }
}
