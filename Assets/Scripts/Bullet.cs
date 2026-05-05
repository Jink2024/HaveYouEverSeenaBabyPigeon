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
            Destroy(other.gameObject);
            Destroy(gameObject);
            print("Bird was hit");
        }
    }
}
