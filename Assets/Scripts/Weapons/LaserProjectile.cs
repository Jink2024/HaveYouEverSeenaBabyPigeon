public class LaserProjectile : Projectile
{
    protected override int Damage => GameParameters.LaserDamage;
    protected override float Speed => GameParameters.LaserMovementSpeed;
    protected override bool DestroyOnBirdHit => false;
}
