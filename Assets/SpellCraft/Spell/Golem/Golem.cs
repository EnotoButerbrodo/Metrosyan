using System;
using System.Collections;
using UnityEngine;

public class Golem : Unit
{
    [SerializeField] private Attack _attackHandler;
    [SerializeField] Spell[] _startBuffs;

    public void Init(Attack attack, IEnumerable startBuffs = null)
    {
        _attackHandler = attack;
        if(startBuffs != null)
        {
            foreach(Spell spell in startBuffs)
            {
                spell.Use(new Ray(transform.position, transform.rotation.eulerAngles), gameObject);
            }
        }
    }

    private void Attack()
    {
        _attackHandler.Hit();
    }
}

