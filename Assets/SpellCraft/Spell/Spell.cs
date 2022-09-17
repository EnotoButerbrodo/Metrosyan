using System;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Базовый класс для заклинаний
/// </summary>

public abstract class Spell : IStorable
{
    public Action<Spell> Used;
    public abstract CastType CastType { get; }

    public Sprite Sprite => null;

    public abstract void Use(Ray direction, GameObject target = null);
}
