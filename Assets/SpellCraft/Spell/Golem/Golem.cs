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
       
    }

    private void Attack()
    {
        _attackHandler.Hit();
    }
}

