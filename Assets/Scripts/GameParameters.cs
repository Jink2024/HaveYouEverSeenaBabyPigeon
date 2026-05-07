using UnityEngine;

public static class GameParameters
{
    public static int PlayerMaxHealth = 10;
    public static int NumberBirdsOnScreen = 1;
    public static float BirdsMinimumSecondsToWait = 3f;
    public static float BirdsMaximumSecondsToWait = 5f;
    public static float BirdMovementSpeed = 10f;
    public static float BulletMovementSpeed = 10f;
    public static int BulletDamage = 1;
    public static float LaserMovementSpeed = 20f;
    public static int LaserDamage = 2;
    public static float BulletFireCooldown = 0.5f;
    public static float LaserFireCooldown = 0.1f;

    public static float PlayerMovementSpeed = 10f;

    public static int PigeonMaxHealth = 2;

    public static float PigeonRestTimeInSeconds = 1.5f;
    public static float BirdExistTimeInSeconds = 5f;
}
