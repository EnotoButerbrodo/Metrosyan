using UnityEngine;

public class SpellPlacer : MonoBehaviour
{

    //����������� ���
    [SerializeField] private Spell _spell;
    //���������� ����� ���� ����� ����������� ����������
    [SerializeField] private InputManager _inputManager;
    private Vector3 _mouseLastPosition;

    private void Update()
    {
        
    }

    public void CastSpell()
    {
        Vector3 spellCastPoint = _inputManager.MousePosition;
        _spell.Use(spellCastPoint, Vector3.zero);
    }
    
  
}

public class InputManager
{
    public Vector3 MousePosition { get; private set; }

    private void Update()
    {
        MousePosition = Input.mousePosition;
    }
}