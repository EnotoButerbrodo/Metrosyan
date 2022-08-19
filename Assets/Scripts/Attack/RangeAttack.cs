using UnityEngine;
public class RangeAttack : IAttack
{ 

    private Projectale _projectale;
    public RangeAttack(Projectale projectale)
    {
        _projectale = projectale;
    }

    public void Hit()
    {
        // передача в ECS
        //Отправляем евент с _projectale -> creatEnemyFactory
        // в creatEnemyFactory -> по типу _projactale -> Fire or Water
        // -> и генерируем голема с выбранными критериями и у него есть аура огня и так далее на ECS;
        MakeSpell.Instance.AddSpellInTheWorld?.Invoke(_projectale);
        Debug.Log("I shoot " + _projectale.Type + " " + _projectale.Damage);
    }
}
