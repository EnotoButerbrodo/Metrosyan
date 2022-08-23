using UnityEngine;

public class Magic : Spell
{
    public SpellConfig _spell;
    public ExtraConfig _extra;

    public override void Use()
    {
       
        InventoryUI._instance._inventory.AddSlotAction(this);
        Debug.Log(string.Format("Golem type = {0}, Name = {1}, Damage = {2}",_spell.Stats.Type, _spell.Stats.Name,_spell.Stats.Damage));
    }
}