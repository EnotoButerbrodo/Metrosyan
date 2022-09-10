using System;
using UnityEngine;

public class Golem : Unit
{
    [SerializeField] private Attack _attackHandler;

    public void Init(Attack attack)
    {
        _attackHandler = attack;
    }

    private void Attack()
    {
        _attackHandler.Hit();
    }
}

