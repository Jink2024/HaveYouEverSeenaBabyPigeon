using UnityEngine;

public class Goose : TimedObjectPlacer
{
    private Bird Bird;
    
    void Start()
    {
        minimumSecondsToWait = GameParameters.BirdsMinimumSecondsToWait;
        maximumSecondsToWait = GameParameters.BirdsMaximumSecondsToWait;
    }

    // Update is called once per frame
    public void Update()
    {
        //Bird.Move(Vector2.down);
    }
}
