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
    public GameObject bird;
    public GameObject Prefab;
    private Rigidbody2D rb;
    private int randomMoveCounter = 0;
    private int lastRandomDirection = 0;
    private SpriteRenderer spriteRenderer;
    bool isOkToCreate = false;
    int NumberBirdsOnScreen = (int)new MaxIntParameter(GameParameters.NumberBirdsOnScreen, GameParameters.NumberBirdsOnScreen);
    
    void Start()
    {
        CountdownUntilCreation();
        NumberBirdsOnScreen = 1;
    }

    public void SpawnBird()
    {
        // Spawn bird prefab (hopefully) at top of screen
        Instantiate(Prefab, SpawnTools.RandomTopOfScreenLocationWorldSpace(), Quaternion.identity);
        if (NumberBirdsOnScreen > 1)
        {
            NumberBirdsOnScreen--;
        }
            
    }
    
    IEnumerator CountdownUntilCreation()
    {
        isOkToCreate = true;
      
        float secondsToWait = 5;
        yield return new WaitForSeconds(secondsToWait);
        print("checking");
        SpawnBird();
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

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bird")
        {
            Destroy(gameObject);
        }
    }
}
