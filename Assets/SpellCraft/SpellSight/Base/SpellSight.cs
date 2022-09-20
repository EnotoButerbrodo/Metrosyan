using UnityEngine;

public abstract class SpellSight : MonoBehaviour
{   
    public abstract Ray GetPosition();

    public abstract void Enable();
    public abstract void Disable();

    public abstract void Move(Vector3 position);
}
