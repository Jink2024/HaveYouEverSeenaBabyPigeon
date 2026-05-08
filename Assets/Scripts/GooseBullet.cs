using Unity.VisualScripting;
using UnityEngine;

public class GooseBullet : MonoBehaviour
{
  private UI ui;
  
  public void Awake()
  {
    ui = FindFirstObjectByType<UI>();
  }
  
  public void OnTriggerEnter2D(Collider other)
  {
    if (other.CompareTag("SlotTrigger"))
    {
      Destroy(gameObject);
    }
    
    if (other.CompareTag("Player"))
    {
      other.GetComponent<Health>().TakeDamage();
      print("Player got hit");
    }
    
    else if (other.CompareTag("DestroyBox"))
    {
      Destroy(gameObject);
      print("Hit Box");
    }
  }
  
}
