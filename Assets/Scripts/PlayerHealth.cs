using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;

    public void Start()
    {
        currentHealth = GameParameters.PlayerMaxHealth;
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
