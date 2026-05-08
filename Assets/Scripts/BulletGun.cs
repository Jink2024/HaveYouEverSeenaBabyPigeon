using UnityEngine;

public class BulletGun : Weapon
{
    public override float FireCooldown => GameParameters.BulletFireCooldown;
}