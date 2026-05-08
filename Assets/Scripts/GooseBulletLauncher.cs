using UnityEngine;
using UnityEngine.InputSystem;

public class GooseBulletLauncher : MonoBehaviour
{
    public Launcher Launcher;
    public Sounds Sounds;
    public Game Game;
    
    private float _lastFireTime = -Mathf.Infinity;
    void Update()
    {
        if (!Game.IsGameRunning())
            return;
        
        if (Mouse.current == null)
            return;
        
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
        
        Sounds.PlayGunSound();
        
        // Launch in that direction
        Launcher.Launch(aimDirection);
    }

    private Vector2 GetAimDirection()
    {
        return Vector2.down;
    }
    
}