using UnityEngine;

public class GolemCrafter : MonoBehaviour
{
    [SerializeField] private CoreSlot _mainTypeSlot;
    [SerializeField] private CoreSlot _extraTypeSlot;
    [SerializeField] private CoreMenu _menu;
    [SerializeField] private ExtraConfig defualtCore;

    
    [SerializeField] private RegularSpells _factory;
    private ElementType extraType = ElementType.Bullet;

    public void Craft()
    {
        if (_mainTypeSlot.Item is null )
            return;

        if(!(_extraTypeSlot.Item is null)) 
        {
            extraType = _extraTypeSlot.Item.Stats.Type;
        }
        
        var golem = _factory.Get(_mainTypeSlot.Item.Stats.Type, extraType);
        golem.Use();
    }


  
}
