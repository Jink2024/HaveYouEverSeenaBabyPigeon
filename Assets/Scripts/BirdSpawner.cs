using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;

public class BirdSpawner : MonoBehaviour
{
    public GameObject Prefab;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    
    private int randomMoveCounter = 0;
    private int lastRandomDirection = 0;
    
    bool isOkToCreate = false;
    
    int NumberBirdsOnScreen = (int)new MaxIntParameter(GameParameters.NumberBirdsOnScreen, GameParameters.NumberBirdsOnScreen);
    
    private Coroutine countdownCoroutine;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        if (isOkToCreate = true)
            countdownCoroutine = StartCoroutine(routine: CountdownUntilCreation());
    }

    public virtual void SpawnBird()
    {
        // Spawn bird prefab (hopefully) at top of screen
        Instantiate(Prefab, SpawnTools.RandomTopOfScreenLocationWorldSpace(), Quaternion.identity);
    }
    
    IEnumerator CountdownUntilCreation()
    {
        isOkToCreate = false;
      
        float secondsToWait = 5;
        
        yield return new WaitForSeconds(secondsToWait);
        WaitForSeconds wait = new WaitForSeconds(secondsToWait);
        SpawnBird();
        isOkToCreate = true;
    }
    
    private void MoveRandomly()
    {
        int direction = lastRandomDirection;
        
        
        //spriteRenderer.transform.Translate( );

        spriteRenderer.transform.position = SpriteTools.ConstrainToScreen(spriteRenderer);
        
        if (randomMoveCounter == 0)
        { 
            direction = Random.Range(0, 4);
            lastRandomDirection = direction;
            randomMoveCounter = Random.Range(20, 69);
        }

        switch (direction)
        {
            case 0:
                MoveRandomly();
                break;
            case 1:
                MoveRandomly();
                break;
            case 2:
                //MoveRandomly(new Vector2(0,1));
                break;
            case 3:
                //Move(new Vector2(0,-1));
                break;
        }

        randomMoveCounter = randomMoveCounter - 1;
    }
    

    void OnTriggerEnter2D(Collider2D other)
    {
        isOkToCreate = false;
        if (other.tag == "Bird")
        {
            Destroy(other.gameObject);
        }
        isOkToCreate = true;
    }
}
