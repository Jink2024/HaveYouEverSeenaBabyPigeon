using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected GameObject projectilePrefab;
    [SerializeField] protected Transform projectileSpawnPoint;
    protected Sounds sounds;

    public virtual float FireCooldown => GameParameters.BulletFireCooldown;
    protected virtual void Awake()
    {
        sounds = FindAnyObjectByType<Sounds>();
    }
    
    public virtual void Shoot(Vector2 aimDirection)
    {
        PlayShootSound();

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
}