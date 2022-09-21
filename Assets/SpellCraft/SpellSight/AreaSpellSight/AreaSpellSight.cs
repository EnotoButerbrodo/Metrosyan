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

    private Vector3 _coliderExtends;

    private bool _available = false;


    public override Ray GetPosition()
    => new Ray(_basicSight.transform.position, Vector3.zero);

    [ContextMenu("Enable")]
    public override void Enable()
    {
        gameObject.SetActive(true);
        _available = true;
        _sightMoveInput.action.Enable();
    }

    [ContextMenu("Disable")]
    public override void Disable()
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

    Collider[] overlap = new Collider[1];
    private void LateUpdate()
    {
        if (_available == false)
        {
            return;
        }

        if (_caster.TryGetSignPosition(_sightMoveInput.action.ReadValue<Vector2>(),
                                         out Vector3 sightPosition,
                                         out RaycastHit hit))
        {
            overlap = new Collider[1];
            Physics.OverlapBoxNonAlloc(hit.point + transform.up * 0.2f, _coliderExtends,overlap, Quaternion.FromToRotation(Vector3.up, hit.normal));
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
