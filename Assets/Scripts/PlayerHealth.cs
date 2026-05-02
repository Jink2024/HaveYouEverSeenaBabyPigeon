using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth = GameParameters.playerMaxHealth;

    public int GetHealth()
    {
        return currentHealth;
    }
    
    public void TakeDamage(int damage = 1)
    {
        currentHealth -= damage;
    }
}
