using UnityEngine;

public class PigeonHealth : Health
{
    void Start()
    {
        MaxHealth = GameParameters.PigeonMaxHealth;
        base.Start();
    }
}
