using System;
using UnityEngine;
[Serializable]
public class Inventory : MonoBehaviour
{
    public Action<Magic> OnAddSlot;

    public void AddSlotAction(Magic spell)
    {
        OnAddSlot?.Invoke(spell);
    }
}
