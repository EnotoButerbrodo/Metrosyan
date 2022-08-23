using System;

[Serializable]
public class Inventory
{
    public event Action<Magic> AddSlot;

    public void AddSlotAction(Magic spell)
    {
        AddSlot?.Invoke(spell);
    }
}
