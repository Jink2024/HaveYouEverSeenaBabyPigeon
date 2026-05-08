using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    private Dictionary<Type, Coroutine> activePowerUps = new();

    public void ActivatePowerUp(PowerUp powerUpPrefab)
    {
        PowerUp powerUp = Instantiate(powerUpPrefab);

        Type powerUpType = powerUp.GetType(); // Return the type of powerUp (Laser, Nuke...)

        // If this type is already activated, reset Coroutine countdown
        if (activePowerUps.ContainsKey(powerUpType))
        {
            StopCoroutine(activePowerUps[powerUpType]);
        }

        Coroutine coroutine = StartCoroutine(RunPowerUp(powerUp));

        activePowerUps[powerUpType] = coroutine;
    }

    private IEnumerator RunPowerUp(PowerUp powerUp)
    {
        yield return powerUp.Apply(gameObject);

        activePowerUps.Remove(powerUp.GetType());

        Destroy(powerUp.gameObject);
    }
}
