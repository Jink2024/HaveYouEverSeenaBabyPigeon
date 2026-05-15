using UnityEngine;

public class Ostrich : Bird
{
    protected override float MovementSpeed => GameParameters.OstrichMovementSpeed;
    public void Update()
    {
        Move(Vector2.down);
    }
}
