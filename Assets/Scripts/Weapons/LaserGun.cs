using UnityEngine;
using DG.Tweening;

public class LaserGun : Weapon
{
    public override float FireCooldown => GameParameters.LaserFireCooldown;
    protected override void PlayShootSound()
    {
        sounds.PlayLaserSound();
    }
    
    protected override void PlayRecoil()
    {
        if (weaponVisual == null)
            return;

        weaponVisual
            .DOPunchPosition(-weaponVisual.up * 0.3f, 0.05f)
            .SetEase(Ease.OutBack);
    }
}
