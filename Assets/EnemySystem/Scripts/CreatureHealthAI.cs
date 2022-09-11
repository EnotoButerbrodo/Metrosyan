using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureHealthAI : CreatureHealth
{
    [SerializeField] private Canvas _canvas;
    [SerializeField][Range(0,10)] private int _speedRotation = 4;
    private Camera _camera;

    public override void OnStart()
    {
        base.OnStart();
        _camera = Camera.main;
    }

    void LateUpdate()
    {
        LookRotationUI(_camera.transform);
    }

    public void LookRotationUI(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        _canvas.transform.rotation = Quaternion.Slerp(_canvas.transform.rotation,lookRotation, Time.deltaTime * _speedRotation);
    }
}
