using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseFacer : MonoBehaviour
{
    private float _lastValidAngle = 0f;
    
    void Update()
    {
        if (Mouse.current == null)
            return;
        
        float angle = GetAngle();

        // If possible angle, accept it
        if (angle >= -90f && angle <= 90f)
        {
            _lastValidAngle = angle;
        }
        
        // rotate the sprite to that angle
        transform.rotation = Quaternion.Euler(0f, 0f, _lastValidAngle);
    }

    private float GetAngle()
    {
        Vector3 mouseWorld = GetMouseWorldPosition();
        float angle = CalculateAngle(mouseWorld);
        return angle;
    }

    private float CalculateAngle(Vector3 targetPosition)
    {
        Vector2 direction = (targetPosition - transform.position).normalized; 
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        angle = angle - 90f;
        return angle;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector2 mouseScreen = Mouse.current.position.ReadValue();
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(mouseScreen);
        mouseWorld.z = 0f;
        return mouseWorld;
    }
}

