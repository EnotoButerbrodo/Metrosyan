using UnityEngine;

public class AreaSpellSight : SpellSight
{
    private Transform _transform;
    public override Ray GetPosition()
        => new Ray(_transform.position, Vector3.zero);
    
    public override void Enable()
    {
        gameObject.SetActive(true);
    }
    public override void Disable()
    {
        gameObject.SetActive(false);
    }

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    public override void Move(Ray position)
    {
        _transform.position = position.origin;
    }
}
