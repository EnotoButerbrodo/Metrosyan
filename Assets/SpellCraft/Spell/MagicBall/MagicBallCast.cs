using UnityEngine;


[CreateAssetMenu(fileName = "MagicBallCast", menuName = "Spell/MagicBallCast")]
public class MagicBallCast : Spell
{
    private MagicBall _ballPrevab;
    private int _damage;

    public MagicBallCast(float reloadTime) : base(reloadTime)
    {
    }

    public override CastType CastType => CastType.Shoot;

    public override CastInitialType CastInitialType => CastInitialType.Instantly;

    public void Init(MagicBall magicBall, int damage, Core core)
    {
        _ballPrevab = magicBall;
        _damage = damage;
    }

    protected override void OnSpellUse(Ray direction, GameObject target = null)
    {
        var ball = GameObject.Instantiate(_ballPrevab, direction.origin + new Vector3(0, 1f), Quaternion.Euler(direction.direction));
        ball.Init(_damage);
        ball.Launch(direction.direction);
    }
}
