using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
public class AreaSpellSight : SpellSight
{

    [SerializeField] private SpriteRenderer _basicSight;
    [SerializeField] private DecalProjector _errorProjector;

    [SerializeField] private Collider _collider;
    [SerializeField] private SpellSightCaster _caster;
    [SerializeField] private InputActionReference _sightMoveInput;

    [SerializeField] private Color _availableColor;
    [SerializeField] private Color _notAvailableColor;

    Collider[] overlap = new Collider[1];

    private Vector3 _coliderExtends;

    private bool _available = false;


    public override Vector3 GetPosition()
    => _basicSight.transform.position;

    public void ChangeColor(Color color)
    {
        _basicSight.color = color;
    }

    protected override void OnEnabled()
    {
        gameObject.SetActive(true);
        _sightMoveInput.action.Enable();
    }

    protected override void OnDisabled()
    {
        gameObject.SetActive(false);
        _available = false;
        _sightMoveInput.action.Disable();
    }

    private void Awake()
    {
        Enable();
        _coliderExtends = _collider.bounds.extents;
        _collider.enabled = false;
    }

    protected override void OnSightEnabled()
    {
        if (_caster.TryGetSignPosition(_sightMoveInput.action.ReadValue<Vector2>(),
                                          out Vector3 sightPosition,
                                          out RaycastHit hit))
        {
            overlap = new Collider[1];
            Physics.OverlapBoxNonAlloc(hit.point + transform.up * 0.2f, _coliderExtends, overlap, Quaternion.FromToRotation(Vector3.up, hit.normal));
            if (overlap[0] is Collider && overlap[0] != _collider)
            {
                _errorProjector.enabled = true;
                _errorProjector.transform.position = sightPosition;
            }
            else
            {
                _errorProjector.enabled = false;
                transform.position = sightPosition;
                transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
            }



        }
    }
}
