using UnityEngine;

public class Health : MonoBehaviour
{
    public int currentHealth;
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
        currentHealth -= damage;
    }
}
