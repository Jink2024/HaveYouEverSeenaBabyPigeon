using UnityEngine;

public class GooseProjectile : Projectile
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SlotTrigger"))
        {
            Destroy(gameObject);
            return;
        }

        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth =
                other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage();
            }

            Destroy(gameObject);
        }

        if (other.CompareTag("Bird"))
        {
            return;
        }
    }
}