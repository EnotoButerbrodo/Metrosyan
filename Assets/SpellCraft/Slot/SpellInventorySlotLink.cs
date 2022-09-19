using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SpellInventorySlotLink : MonoBehaviour
{
    public SpellSlot SpellSlot => _spellSlot;
    public SpellInventorySlot SpellInventorySlot => _spellInventorySlot;

    public Timer ReloadTimer => _reloadTimer;

    public Timer CastTimer => _castTimer;

    [Header("InventoryHandler")]
    [SerializeField] private SpellSlot _spellSlot;
    [SerializeField] private SpellInventorySlot _spellInventorySlot;

    [Header("ReloadHandler")]
    [SerializeField] private Timer _reloadTimer;
    [SerializeField] private Timer _castTimer;

}
