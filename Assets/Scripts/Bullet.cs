using UnityEngine;

public class Bullet : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SlotTrigger"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("Bird"))
        {
            PigeonHealth pigeonHealth = other.GetComponent<PigeonHealth>();
            
            pigeonHealth.TakeDamage();
            
            if (pigeonHealth.GetHealth() == 0)
            {
                Destroy(other.gameObject);
            }
            
            Destroy(gameObject);
            print("Bird was hit");
        }
    }
}
