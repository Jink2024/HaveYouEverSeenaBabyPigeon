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
            ScoreKeeper.AddPoint();
            ScoreKeeper.score = ScoreKeeper.score + 1;
            print("Bird was hit");
        }
    }
}
