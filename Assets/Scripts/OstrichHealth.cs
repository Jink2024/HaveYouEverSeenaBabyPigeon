using UnityEngine;

public class OstrichHealth : Health
{
    public new void Start()
    {
        MaxHealth = GameParameters.OstrichMaxHealth;
        base.Start();
    }
}
