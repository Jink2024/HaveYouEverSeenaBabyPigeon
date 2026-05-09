using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    private UI ui;
    private Rigidbody2D projectileRigidbody;
    
    protected virtual int Damage => GameParameters.BulletDamage;
    protected virtual float Speed => GameParameters.BulletMovementSpeed;
    protected virtual bool DestroyOnBirdHit => true;

    protected virtual void Awake()
    {
        ui = FindAnyObjectByType<UI>();
        projectileRigidbody = GetComponent<Rigidbody2D>();
    }

    public virtual void Launch(Vector2 aimDirection)
    {
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
        projectileRigidbody.AddForce(aimDirection * Speed, ForceMode2D.Impulse);
    }
    
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SlotTrigger"))
        {
            Destroy(gameObject);
            return;
        }

        if (other.CompareTag("Bird"))
        {
            Health health = other.GetComponent<Health>();

            if (health == null)
                return;

            health.TakeDamage(Damage);
            other.GetComponent<SpriteRenderer>().color = Color.red;
            
            if (health.GetHealth() <= 0)
            {
                BirdLoot birdLoot = other.GetComponent<BirdLoot>();
                if (birdLoot != null)
                {
                    birdLoot.DropLoot();
                }
                
                Destroy(other.gameObject);
                ScoreKeeper.AddPoint();
                ui.SetScoreText(ScoreKeeper.GetScoreAsString());
            }
            
            if (DestroyOnBirdHit)
            {
                Destroy(gameObject);
            }

            print("Bird was hit");
        }
    }
}
