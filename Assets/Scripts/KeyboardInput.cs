using UnityEngine;
using UnityEngine.InputSystem;

public class KeyboardInput : MonoBehaviour
{
    public Player Player;
    
    void Update()
    {
        Keyboard keyboard = Keyboard.current;
       
        if (keyboard.aKey.isPressed)
        {
            Player.MoveManually(Vector2.left);
        }
        if (keyboard.dKey.isPressed)
        {
            Player.MoveManually(Vector2.right);
        }
    }
}
