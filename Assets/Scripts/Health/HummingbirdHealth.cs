using UnityEngine;

public class HummingbirdHealth : Health
{
    public new void Start()
    {
        MaxHealth = GameParameters.HummingbirdMaxHealth;
        base.Start();
    }
}
