using UnityEngine;

public class PlayerHealth : Health
{
    public new void Start()
    {
        MaxHealth = GameParameters.PlayerMaxHealth;
        base.Start();
    }
}
