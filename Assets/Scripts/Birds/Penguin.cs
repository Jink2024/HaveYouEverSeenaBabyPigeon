using NUnit.Framework.Constraints;
using UnityEngine;

public class Penguin : Bird
{
    public Animator animator;
    private int direction;

    public void Awake()
    {
        direction = Random.Range(0, 2);
    }
    
    public void Update()
    {
        switch (direction)
        {
            case 0:
                Move(Vector2.right);
                break;
            case 1:
                Move(Vector2.left);
                break;
        }
    }

    public override void AddScreenConstraints()
    {
        return;
    }
}
