using UnityEngine;

public class LaserGun : Weapon
{
    public override float FireCooldown => GameParameters.LaserFireCooldown;
}
