using UnityEngine;

public class GooseHealth : Health
{
    public new void Start()
    {
        MaxHealth = GameParameters.GooseMaxHealth;
        base.Start();
    }
}
