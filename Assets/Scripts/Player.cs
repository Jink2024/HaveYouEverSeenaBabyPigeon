using System;
using System.Collections;
using System.Threading;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    public Sounds Sounds;

    private SpriteRenderer spriteRenderer;
    

    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    public void MoveManually(Vector2 direction)
    {
        Move(direction);
    }

    public void Move(Vector2 direction)
    {
        // Useless for now, could be used later.
        // FaceCorrectDirection(direction);
        
        Vector2 movementAmount = direction * (10 * Time.deltaTime); // Add in GameParameters later
        
        spriteRenderer.transform.Translate(movementAmount.x,0,0);

        spriteRenderer.transform.position = SpriteTools.ConstrainToScreen(spriteRenderer);
    }
    
    private void FaceCorrectDirection(Vector2 direction)
    {
        if (direction.x > 0)
        { 
            spriteRenderer.flipX = false;
        }
        else if (direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    public Vector3 GetPosition()
    {
        return spriteRenderer.transform.position;
    }
}
