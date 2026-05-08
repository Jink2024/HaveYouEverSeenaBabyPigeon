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
            PigeonHealth pigeonHealth = other.GetComponent<PigeonHealth>();
            
            pigeonHealth.TakeDamage();
            other.GetComponent<SpriteRenderer>().color = Color.red;
            
            if (pigeonHealth.GetHealth() == 0)
            {
                Destroy(other.gameObject);
            }
            
            Destroy(gameObject);
            ScoreKeeper.AddPoint();
            ui.SetScoreText(ScoreKeeper.GetScoreAsString());
            print("Bird was hit");
        }

        if (other.CompareTag("Goose"))
        {
            Destroy(other.gameObject);
            ScoreKeeper.AddPoint();
            ui.SetScoreText(ScoreKeeper.GetScoreAsString());
            print("Goose was hit");
        }
    }
}
