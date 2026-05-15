using System.Collections;
using UnityEngine;

public class Goose : Bird // TimedObjectPlacer
{

    private int direction;
    protected override float MovementSpeed => GameParameters.GooseMovementSpeed;
    public void Awake()
    {
        direction = Random.Range(0, 2);
    }
    
    public void Update()
    {
        switch (direction)
        {
            case 0:
                Move(Vector2.right);
                break;
            case 1:
                Move(Vector2.left);
                break;
        }
    }
}
