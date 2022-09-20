using UnityEngine;

public class SpellSightCaster : MonoBehaviour
{
    [SerializeField] private LayerMask _castLayerMask;
    private Camera _camera;
    public bool TryGetSignPosition(Vector3 mousePosition, out Vector3 signPosition)
    {
        signPosition = Vector3.zero;

        Ray ray = _camera.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _castLayerMask))
        {
            signPosition = hit.point;
            return true;
        }

        return false;
    }
    private void Awake()
    {
        _camera = Camera.main;
    }
}