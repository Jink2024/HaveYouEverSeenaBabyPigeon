using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    private class ActivePowerUp
    {
        public PowerUp PowerUp;
        public Coroutine Coroutine;
    }
    
    private Dictionary<Type, ActivePowerUp> activePowerUps = new();

    public void ActivatePowerUp(PowerUp powerUpPrefab)
    {
        PowerUp powerUp = Instantiate(powerUpPrefab);

        Type powerUpType = powerUp.GetType(); // Return the type of powerUp (Laser, Nuke...)

        // If this type is already activated, destroy this powerUp and stop Coroutine
        if (activePowerUps.ContainsKey(powerUpType))
        {
            ActivePowerUp existing = activePowerUps[powerUpType];

            StopCoroutine(existing.Coroutine);

            Destroy(existing.PowerUp.gameObject);
        }

        Coroutine coroutine = StartCoroutine(RunPowerUp(powerUp));

        activePowerUps[powerUpType] = new ActivePowerUp {PowerUp = powerUp, Coroutine = coroutine};
    }

    private IEnumerator RunPowerUp(PowerUp powerUp)
    {
        yield return powerUp.Apply(gameObject);

        activePowerUps.Remove(powerUp.GetType());

        Destroy(powerUp.gameObject);
    }
}
