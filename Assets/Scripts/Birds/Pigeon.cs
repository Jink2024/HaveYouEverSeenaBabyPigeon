using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pigeon : Bird
{
    public List<Transform> RestingPositions;
    private bool isMoving = true;
    private Transform newRestingPosition;
    private Coroutine restingCountdownCoroutine;
    private const float ArrivalDistance = 0.1f;
    private Animator animator;

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }
    
    public void Update()
    {
        if (isMoving)
        {
            MoveTowardsRestingPosition();
            CheckArrival();
        }
    }
    
    private void CheckArrival()
    {
        if (newRestingPosition == null) return;

        float distance =
            Vector2.Distance(
                transform.position,
                newRestingPosition.position
            );

        if (distance < ArrivalDistance)
        {
            if (restingCountdownCoroutine != null)
                StopCoroutine(restingCountdownCoroutine);

            restingCountdownCoroutine =
                StartCoroutine(RestingCountdown());
        }
    }

    
    private void MoveTowardsRestingPosition()
    {
        Vector2 direction = GetMovementDirection();
        
        Vector2 movementAmount = direction * (GameParameters.BirdMovementSpeed * Time.deltaTime);

        Move(direction);
        animator.SetFloat("Horizontal", Mathf.Abs(movementAmount.x));

    }

    private Vector2 GetMovementDirection()
    {
        if (newRestingPosition ==null) 
            newRestingPosition = GetRandomRestingPositionLocation();
        
        Vector2 moveDirection = newRestingPosition.position - transform.position;
        return moveDirection.normalized;
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
        newRestingPosition = GetRandomRestingPositionLocation();
        MoveTowardsRestingPosition();
    }
}
