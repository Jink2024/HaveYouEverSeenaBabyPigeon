using UnityEngine;

public class Health : MonoBehaviour
{
    public static int currentHealth;
    public int MaxHealth;
    public void Start()
    {
        currentHealth = MaxHealth;
    }
    
    public int GetHealth()
    {
        return currentHealth;
    }
    
    public void TakeDamage(int damage = 1)
    {
        currentHealth = currentHealth - damage;
    }
    
    public static string HealthAsString()
    {
        return currentHealth.ToString();
    }
}
