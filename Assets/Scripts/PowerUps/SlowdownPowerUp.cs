using System.Collections;
using UnityEngine;

public class SlowdownPowerUp : PowerUp
{
    private float slowdownMultiplier = GameParameters.SlowdownMultiplier;
    private float duration = GameParameters.SlowdownDuration;
    
    private Sounds sounds;

    private void Awake()
    {
        sounds = FindAnyObjectByType<Sounds>();
    }

    public override IEnumerator Apply(GameObject player)
    {
        GameParameters.BirdSpeedMultiplier = slowdownMultiplier;
        if (sounds)
        {
            sounds.PlaySlowdownSound();
        }

        yield return new WaitForSeconds(duration);

        GameParameters.BirdSpeedMultiplier = 1f;
        sounds.StopSlowdownSound();
    }
}