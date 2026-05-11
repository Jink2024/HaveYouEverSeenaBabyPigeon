using Unity.VisualScripting;
using UnityEngine;

public class GooseBullet : MonoBehaviour
{
  public UI Ui;
  public Health Health;
  
  public void Awake()
  {
    Ui = FindFirstObjectByType<UI>();
  }
  
  public void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("SlotTrigger"))
    {
      Destroy(gameObject);
    }
    
    if (other.CompareTag("Player"))
    {
      Destroy(gameObject);
      //      Ui.SetHealthText(Ui.healthText.text = $"Health: {Health.currentHealth}");
      other.GetComponent<PlayerHealth>().TakeDamage();

    }
    
    else if (other.CompareTag("DestroyBox"))
    {
      Destroy(gameObject);
    }
    
    else if (other.CompareTag("Bird"))
    {
      Destroy(gameObject);
      return;
    }
  }
  
}
