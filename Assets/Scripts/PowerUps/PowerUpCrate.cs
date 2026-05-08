using UnityEngine;

public class PowerUpCrate : MonoBehaviour
{
    [SerializeField] private PowerUp powerUpPrefab;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SlotTrigger"))
        {
            Destroy(gameObject);
            return;
        }

        if (other.CompareTag("Player"))
        {
            PowerUpManager manager = other.GetComponent<PowerUpManager>();

            if (manager != null)
            {
                manager.ActivatePowerUp(powerUpPrefab);
            }
            Destroy(gameObject);
        }
    }
}
