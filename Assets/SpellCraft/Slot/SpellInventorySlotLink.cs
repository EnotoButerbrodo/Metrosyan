using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SpellInventorySlotLink : MonoBehaviour
{
    public SpellSlot SpellSlot => _spellSlot;
    public SpellInventorySlot SpellInventorySlot => _spellInventorySlot;
    public Image SelectImage => _selectImage;
    public Image ReloadImage => _reloadImage;
    public Timer ReloadTimer => _reloadTimer;
    public InputActionReference InputAction => _inputAction;

    [SerializeField] private SpellSlot _spellSlot;
    [SerializeField] private SpellInventorySlot _spellInventorySlot;
    [SerializeField] private Image _selectImage;
    [SerializeField] private Image _reloadImage;
    [SerializeField] private Timer _reloadTimer;
    [SerializeField] private InputActionReference _inputAction;

}
