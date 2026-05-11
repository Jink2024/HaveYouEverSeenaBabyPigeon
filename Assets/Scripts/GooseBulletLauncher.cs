using UnityEngine;
using UnityEngine.InputSystem;

public class GooseBulletLauncher : MonoBehaviour
{
    public Launcher Launcher;
    public Sounds Sounds;
    public Game Game;
    private Player player;
    
    private float _lastFireTime = -Mathf.Infinity;
    
    public void Awake()
    {
        Game = FindObjectOfType<Game>();
        Sounds = FindObjectOfType<Sounds>();
        player = FindObjectOfType<Player>();
    }
    
    void Update()
    {
        if (!Game.IsGameRunning())
            return;
        
        Vector2 aimDirection = GetAimDirection();
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);

        if (CanFire())
        {
            Launch();
        }
    }
    
    private bool CanFire()
    {
        return Time.time >= _lastFireTime + GameParameters.GooseFireCooldown;
    }

    private void Launch()
    {
        _lastFireTime = Time.time;
        
        // figure out the direction to aim
        Vector2 aimDirection = GetAimDirection();
        
        // Launch in that direction
        Launcher.Launch(aimDirection);
        
        Sounds.PlayGunSound();
    }

    private Vector2 GetAimDirection()
    {
        return (player.transform.position - transform.position).normalized;
    }
    
}