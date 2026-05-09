using UnityEngine;

public class LaserGun : Weapon
{
    public override float FireCooldown => GameParameters.LaserFireCooldown;
    protected override void PlayShootSound()
    {
        sounds.PlayLaserSound();
    }
}
