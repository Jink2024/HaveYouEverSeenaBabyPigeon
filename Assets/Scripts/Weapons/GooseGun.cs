using UnityEngine;

public class GooseGun : Weapon
{
    public override float FireCooldown => GameParameters.GooseFireCooldown;

    protected override void PlayShootSound()
    {
        sounds.PlayBulletSound();
    }
}