using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Coroutine flashCoroutine;
    private float damageFlashDuration = GameParameters.DamageFlashDuration;
    public int currentHealth;
    public int MaxHealth;
    private UI ui;
    [SerializeField] private GameObject deathEffectPrefab;
    
    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = MaxHealth;
        ui = FindAnyObjectByType<UI>();
    }
    
    public int GetHealth()
    {
        return currentHealth;
    }
    
    public virtual void TakeDamage(int damage = 1)
    {
        currentHealth = currentHealth - damage;
        
        if (flashCoroutine != null)
        {
            StopCoroutine(flashCoroutine);
        }
        flashCoroutine = StartCoroutine(FlashRed());
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
    private IEnumerator FlashRed()
    {
        if (spriteRenderer == null)
            yield break;

        spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(damageFlashDuration);

        spriteRenderer.color = Color.white;
    }
    
    public string HealthAsString()
    {
        return currentHealth.ToString();
    }
    
    public virtual void Die()
    {
        if (CompareTag("Bird"))
        {
            if (deathEffectPrefab != null)
            {
                GameObject effect =
                    Instantiate(
                        deathEffectPrefab,
                        transform.position,
                        Quaternion.identity
                    );

                Destroy(effect, 2f);
            }
            
            BirdLoot birdLoot = GetComponent<BirdLoot>();

            if (birdLoot != null)
            {
                birdLoot.DropLoot();
            }
            
            ScoreKeeper.AddPoint();

            if (ui != null)
            {
                ui.SetScoreText(ScoreKeeper.GetScoreAsString());
            }
        }

        Destroy(gameObject);
    }
}
