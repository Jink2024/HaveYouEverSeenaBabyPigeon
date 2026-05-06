using UnityEngine;

public class Hummingbird : Bird
{
    private int randomMoveCounter = 0;
    private int lastRandomDirection;

    public void Update()
    {
        MoveRandomly();
    }

    private void MoveRandomly()
    {
        int direction = lastRandomDirection;
        
        if (randomMoveCounter == 0)
        {
            direction = Random.Range(0, 8);
            lastRandomDirection = direction;
            randomMoveCounter = Random.Range(20, 69);
        }
        
        switch  (direction)
        {
            case 0:
                Move(Vector2.right);
                break;
            case 1:
                Move(new Vector2(1,1));
                break;
            case 2:
                Move(Vector2.up);
                break;
            case 3:
                Move(new Vector2(-1, 1));
                break;
            case 4:
                Move(Vector2.left);
                break;
            case 5:
                Move(new Vector2(-1, -1));
                break;
            case 6:
                Move(Vector2.down);
                break;
            case 7:
                Move(new Vector2(1,-1));
                break;
        }
        
        randomMoveCounter--;
    }
}
