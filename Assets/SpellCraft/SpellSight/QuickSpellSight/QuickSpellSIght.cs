using UnityEngine;
using UnityEngine.InputSystem;

public class QuickSpellSIght : SpellSight
{
    public override Vector3 GetPosition()
        => transform.position;

    protected override void OnSightEnabled()
    {
        
    }

    protected override void OnEnabled()
    {
        throw new System.NotImplementedException();
    }

    protected override void OnDisabled()
    {
        throw new System.NotImplementedException();
    }

  


}
