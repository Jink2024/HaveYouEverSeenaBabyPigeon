using UnityEngine;

public class PlayerHealth : Health
{
    public UI Ui;
    
    public new void Start()
    {
        MaxHealth = GameParameters.PlayerMaxHealth;
        base.Start();
    }

    public override void TakeDamage(int damage = 1)
    {
        base.TakeDamage();
        Ui.SetHealthText(GetHealth().ToString());
    }

    public void Reset()
    {
        currentHealth = MaxHealth;
    }
}
