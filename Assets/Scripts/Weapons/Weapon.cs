using UnityEngine;
using DG.Tweening;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected GameObject projectilePrefab;
    [SerializeField] protected Transform projectileSpawnPoint;
    [SerializeField] protected Transform weaponVisual;

    protected Sounds sounds;

    public virtual float FireCooldown => GameParameters.BulletFireCooldown;
    protected virtual void Awake()
    {
        sounds = FindAnyObjectByType<Sounds>();
    }
    
    public virtual void Shoot(Vector2 aimDirection)
    {
        PlayShootSound();
        PlayRecoil();
        
        GameObject projectileObject =
            Instantiate(
                projectilePrefab,
                projectileSpawnPoint.position,
                Quaternion.identity
            );

        Projectile projectile =
            projectileObject.GetComponent<Projectile>();

        if (projectile == null)
        {
            Debug.LogError(
                $"{projectilePrefab.name} needs a Projectile component."
            );

            Destroy(projectileObject);
            return;
        }

        projectile.Launch(aimDirection);
    }
    
    protected virtual void PlayShootSound()
    {
    }
    
    protected virtual void PlayRecoil()
    {
        if (weaponVisual == null)
            return;

        weaponVisual
            .DOPunchPosition(-weaponVisual.up * 0.2f, 0.1f)
            .SetEase(Ease.OutBack);
    }
}