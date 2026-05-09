using UnityEngine;

public class BulletGun : Weapon
{
    public override float FireCooldown => GameParameters.BulletFireCooldown;
    
    protected override void PlayShootSound()
    {
        sounds.PlayBulletSound();
    }
}