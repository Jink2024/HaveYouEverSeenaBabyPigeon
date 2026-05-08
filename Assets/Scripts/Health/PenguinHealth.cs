using UnityEngine;

public class PenguinHealth : Health
{
    public new void Start()
    {
        MaxHealth = GameParameters.PenguinMaxHealth;
        base.Start();
    }
}
