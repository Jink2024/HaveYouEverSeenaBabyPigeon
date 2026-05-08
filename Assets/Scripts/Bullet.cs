using UnityEngine;

public class Bullet : MonoBehaviour
{
    private UI ui;

     public void Awake()
    {
        ui = FindObjectOfType<UI>();
    }
    
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SlotTrigger"))
        {
            Destroy(gameObject);
        }
        
        if (other.CompareTag("Bird"))
        {
            Destroy(gameObject);
            PigeonHealth pigeonHealth = other.GetComponent<PigeonHealth>();
            
            pigeonHealth.TakeDamage();
            other.GetComponent<SpriteRenderer>().color = Color.red;
            
            if (pigeonHealth.GetHealth() == 0)
            {
                Destroy(other.gameObject);
            }
            
            Destroy(other.gameObject);
            ScoreKeeper.AddPoint();
            ui.SetScoreText(ScoreKeeper.GetScoreAsString());
        }

        if (other.CompareTag("Goose"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            ScoreKeeper.AddPoint();
            ui.SetScoreText(ScoreKeeper.GetScoreAsString());
        }
    }
}
