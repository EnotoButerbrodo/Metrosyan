using UnityEngine;

public class Golem : Spell
{
    [SerializeField] private IAttack _attackHandler;
    [SerializeField] private SpellConfig _config;
    public void Init(IAttack attack, SpellConfig config)
    {
        _attackHandler = attack;
        _config = config;
    }

    public override void Use()
    {
        Debug.Log($"Spawn golem");
        Attack();
    }

    private void Attack()
    {
        _attackHandler.Hit();
    }
  
}
