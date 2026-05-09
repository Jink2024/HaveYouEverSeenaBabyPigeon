using System.Collections;
using UnityEngine;

public class NukePowerUp : PowerUp
{
    private Sounds sounds;
    private UI ui;
    
    private void Awake()
    {
        sounds = FindAnyObjectByType<Sounds>();
        ui = FindAnyObjectByType<UI>();
    }
    
    public override IEnumerator Apply(GameObject player)
    {
        GameObject[] birds = GameObject.FindGameObjectsWithTag("Bird");

        foreach (GameObject bird in birds)
        {
            if (bird == null)
                continue;

            Destroy(bird);

            ScoreKeeper.AddPoint();
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

        if (ui != null)
        {
            ui.SetScoreText(ScoreKeeper.GetScoreAsString());
        }
        
        yield break;
    }
}