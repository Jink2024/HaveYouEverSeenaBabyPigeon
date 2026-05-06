using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;

public class BirdSpawner : TimedObjectPlacer
{
    // public Sounds Sounds;
    
    void Start()
    {
        if (Game.isGameRunning == false)
            return;
        Place();

    }

     public override void Place()
    {
        minimumSecondsToWait = GameParameters.BirdsMinimumSecondsToWait;
        maximumSecondsToWait = GameParameters.BirdsMaximumSecondsToWait;
        
        Instantiate(Prefab, SpawnTools.RandomTopOfScreenLocationWorldSpace(), Quaternion.identity);
        // Sounds.PlayFallingSound();
    }
    
}
