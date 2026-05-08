using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected GameObject projectilePrefab;
    [SerializeField] protected Transform projectileSpawnPoint;
    [SerializeField] protected AudioClip shootSound;
    [SerializeField] protected AudioSource audioSource;
    public virtual float FireCooldown => GameParameters.BulletFireCooldown;
    public virtual void Shoot(Vector2 aimDirection)
    {
        audioSource.PlayOneShot(shootSound);

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
}