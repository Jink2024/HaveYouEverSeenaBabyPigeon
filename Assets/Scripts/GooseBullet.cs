using Unity.VisualScripting;
using UnityEngine;

public class GooseBullet : MonoBehaviour
{
  public void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Player"))
    {
      other.GetComponent<Health>().TakeDamage();
    }
  }
  
}
