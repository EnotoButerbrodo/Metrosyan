using UnityEngine;


[CreateAssetMenu(fileName = "MagicBallCast", menuName = "Spell/MagicBallCast")]
public class MagicBallCast : Spell
{
    private MagicBall _ballPrevab;
    private int _damage;

    public override CastType CastType => CastType.Shoot;

    public void Init(MagicBall magicBall, int damage, Core core)
    {
        _ballPrevab = magicBall;
        _damage = damage;
    }

    public override void Use(Ray direction, GameObject target = null)
    {
        var ball = GameObject.Instantiate(_ballPrevab, direction.origin + new Vector3(0, 1f), Quaternion.Euler(direction.direction));
        ball.Init(_damage);
        ball.Launch(direction.direction);
    }
}
