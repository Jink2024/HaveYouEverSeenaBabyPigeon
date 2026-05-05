using UnityEngine;

public class PlayerHealth : Health
{
    void Start()
    {
        MaxHealth = GameParameters.PlayerMaxHealth;
        base.Start();
    }
}
