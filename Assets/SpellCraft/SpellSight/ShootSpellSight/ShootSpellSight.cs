using UnityEngine;

public class ShootSpellSight : SpellSight
{
    public override void Enable()
    {
        gameObject.SetActive(true);
    }
    public override void Disable()
    {
        gameObject.SetActive(false);
    }

    public override Ray GetPosition()
    {
        return new Ray(transform.position, transform.rotation.eulerAngles);
    }

    public override void Move(Ray position)
    {
        transform.LookAt(position.direction);
    }
}