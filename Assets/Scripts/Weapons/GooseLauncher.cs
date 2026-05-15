using UnityEngine;

public class GooseLauncher : MonoBehaviour
{
    private Launcher launcher;

    private Player player;
    private Game game;
    [SerializeField] private float attackDelay = 2f;
    private float spawnTime;
    private void Awake()
    {
        launcher = GetComponentInParent<Launcher>();
        player = FindAnyObjectByType<Player>();
        game = FindAnyObjectByType<Game>();
        spawnTime = Time.time;
    }

    private void Update()
    {
        if (!game.IsGameRunning())
            return;

        if (player == null)
            return;

        AimAtPlayer();
        
        if (Time.time < spawnTime + attackDelay)
            return;

        launcher.Launch(GetAimDirection());
    }

    private Vector2 GetAimDirection()
    {
        return
            (player.transform.position - transform.position)
            .normalized;
    }

    private void AimAtPlayer()
    {
        Vector2 direction = GetAimDirection();

        float angle =
            Mathf.Atan2(direction.y, direction.x)
            * Mathf.Rad2Deg;

        transform.rotation =
            Quaternion.Euler(0f, 0f, angle - 90f);
    }
}