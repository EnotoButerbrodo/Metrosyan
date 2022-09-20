using UnityEngine;

public class AreaSpellSight : SpellSight
{
    [SerializeField] private SpriteRenderer _renderer;

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

    public override void Move(Vector3 position)
    {
        
        _transform.position = position + (transform.up * 0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        _renderer.gameObject.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        _renderer.gameObject.SetActive(true);
    } 
     
    public override void SetColor(Color color)
    {
        throw new System.NotImplementedException();
    }
}
