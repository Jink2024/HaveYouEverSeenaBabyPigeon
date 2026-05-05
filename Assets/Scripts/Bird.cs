using UnityEngine;

public class Bird : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private int randomMoveCounter = 0;
    private int lastRandomDirection;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    private void MoveRandomly()
    {
        int direction = lastRandomDirection;
        
        if (randomMoveCounter == 0)
        {
            direction = Random.Range(0, 4);
            lastRandomDirection = direction;
            randomMoveCounter = Random.Range(20, 69);
        }
        
        switch  (direction)
        {
            case 0:
                Move(Vector2.right);
                break;
            case 1:
                Move(Vector2.left);
                break;
            case 2:
                Move(Vector2.up);
                break;
            case 3:
                Move(Vector2.down);
                break;
        }
        
        randomMoveCounter--;
    }

    public void Move(Vector2 direction)
    {
        FaceCorrectDirection(direction);
        Vector2 movementAmount = GameParameters.BirdMovementSpeed * direction * Time.deltaTime;
        spriteRenderer.transform.Translate(movementAmount.x, movementAmount.y, 0);
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
}
