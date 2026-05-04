using UnityEngine;

public class Bird : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private int randomMoveCounter = 0;
    private int lastRandomDirection = 0;
    bool isOkToCreate = true;
    
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
    

    
}
