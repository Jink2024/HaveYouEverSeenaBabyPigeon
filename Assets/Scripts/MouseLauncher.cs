using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLauncher : MonoBehaviour
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
        
        if (Mouse.current.leftButton.wasPressedThisFrame && CanFire())
        {
            Launch();
        }
    }
    
    private bool CanFire()
    {
        return Time.time >= _lastFireTime + GameParameters.FireCooldown;
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
        Vector3 mouseWorld = GetMouseWorldPosition();
        return (mouseWorld - transform.position).normalized;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector2 mouseScreen = Mouse.current.position.ReadValue();
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(mouseScreen);
        mouseWorld.z = 0f;
        return mouseWorld;
    }
}
