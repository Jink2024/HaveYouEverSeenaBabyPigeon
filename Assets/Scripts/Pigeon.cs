using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pigeon : Bird
{
    public List<Transform> RestingPositions;
    private bool isMoving = true;
    private Transform newRestingPosition;
    private Coroutine restingCountdownCoroutine;

    public void Update()
    {
        if (isMoving) MoveTowardsRestingPosition();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RestPosition") && (collision.gameObject.transform.position == newRestingPosition.position))
        {
            if (restingCountdownCoroutine != null) StopCoroutine(restingCountdownCoroutine);
            StartCoroutine(RestingCountdown());
        }
    }
    
    private void MoveTowardsRestingPosition()
    {
        Vector2 direction = GetMovementDirection();
        Move(direction);
    }

    private Vector2 GetMovementDirection()
    {
        newRestingPosition = GetRandomRestingPositionLocation();
        Vector2 moveDirection = new Vector2((newRestingPosition.position.x - transform.position.x), (newRestingPosition.position.y - transform.position.y)).normalized;
        return moveDirection;
    }

    private Transform GetRandomRestingPositionLocation()
    {
        int randomRestingPositionNumber = Random.Range(0, RestingPositions.Count);
        return RestingPositions[randomRestingPositionNumber];
    }

    private IEnumerator RestingCountdown()
    {
        isMoving = false;
        yield return new WaitForSeconds(GameParameters.PigeonRestTimeInSeconds);
        isMoving = true;
        MoveTowardsRestingPosition();
    }
}
