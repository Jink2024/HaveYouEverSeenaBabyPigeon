using System.Collections;
using UnityEngine;

public class NukePowerUp : PowerUp
{
    private Sounds sounds;
    
    private void Awake()
    {
        sounds = FindAnyObjectByType<Sounds>();
    }
    
    public override IEnumerator Apply(GameObject player)
    {
        GameObject[] birds = GameObject.FindGameObjectsWithTag("Bird");

        foreach (GameObject bird in birds)
        {
            if (bird == null)
                continue;

            Health health = bird.GetComponent<Health>();

            if (health != null)
            {
                health.Die();
            }
        }
        
        if (sounds != null)
        {
            sounds.PlayNukeSound();
        }
        CameraShake shake = Camera.main.GetComponent<CameraShake>();

        if (shake != null)
        {
            shake.Shake(0.4f, 0.5f, 20);
        }
        
        yield break;
    }
}