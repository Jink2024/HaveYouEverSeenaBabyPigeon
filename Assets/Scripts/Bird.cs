using System.Collections;
using UnityEngine;

public class Bird : TimedObjectPlacer
{
    private SpriteRenderer spriteRenderer;
    private bool isLeaving = false;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(RemainOnScreenCountdown());
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SlotTrigger"))
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator RemainOnScreenCountdown()
    {
        yield return new WaitForSeconds(GameParameters.BirdExistTimeInSeconds);
        isLeaving = true;
    }

    public void Move(Vector2 direction)
    {
        if (isLeaving) direction.y = 1;
        FaceCorrectDirection(direction);
        Vector2 movementAmount = GameParameters.BirdMovementSpeed * direction * Time.deltaTime;
        spriteRenderer.transform.Translate(movementAmount.x, movementAmount.y, 0);
        AddScreenConstraints();
    }

    public virtual void AddScreenConstraints()
    {
        if (!isLeaving) spriteRenderer.transform.position = SpriteTools.ConstrainToScreen(spriteRenderer);
    }

    private void FaceCorrectDirection(Vector2 direction)
    {
        if (direction.x >= 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }
}
