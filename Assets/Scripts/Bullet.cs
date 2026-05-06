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
            Destroy(other.gameObject);
            Destroy(gameObject);
            ScoreKeeper.AddPoint();
            ui.SetScoreText(ScoreKeeper.GetScoreAsString());
            print("Bird was hit");
        }
    }
}
