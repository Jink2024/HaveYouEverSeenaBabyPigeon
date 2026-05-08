public class BulletProjectile : Projectile
{
    protected override int Damage => GameParameters.BulletDamage;
    protected override float Speed => GameParameters.BulletMovementSpeed;
    protected override bool DestroyOnBirdHit => true;
}
