using UnityEngine;

public class PowerUpCrate : MonoBehaviour
{
    [SerializeField] private PowerUp powerUpPrefab;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        PowerUpManager manager =
            other.GetComponent<PowerUpManager>();

        if (manager != null)
        {
            manager.ActivatePowerUp(powerUpPrefab);
        }

        Destroy(gameObject);
    }
}
