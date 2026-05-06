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
    public Game Game;
    // public Sounds Sounds;
    public void Start()
    {
        minimumSecondsToWait = GameParameters.BirdsMinimumSecondsToWait;
        maximumSecondsToWait = GameParameters.BirdsMaximumSecondsToWait;
        //if (Game.isGameRunning == true)
       // {
       //     print("game is  running");
       //     Place();
        //}
    }

    public override void Place()
    {
        Instantiate(Prefab, SpawnTools.RandomTopOfScreenLocationWorldSpace(), Quaternion.identity);
        // Sounds.PlayFallingSound();
    }
}
