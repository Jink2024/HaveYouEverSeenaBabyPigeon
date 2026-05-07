using UnityEngine;

public class PigeonHealth : Health
{
    public new void Start()
    {
        MaxHealth = GameParameters.PigeonMaxHealth;
        base.Start();
    }
}
