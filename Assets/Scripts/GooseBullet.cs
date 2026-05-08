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
      other.GetComponent<Health>().TakeDamage();
      //      Ui.SetHealthText(Ui.healthText.text = $"Health: {Health.currentHealth}");
      Ui.SetHealthText(Health.HealthAsString());

    }
    
    else if (other.CompareTag("DestroyBox"))
    {
      Destroy(gameObject);
    }
  }
  
}
