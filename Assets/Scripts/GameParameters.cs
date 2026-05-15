using UnityEngine;

public static class GameParameters
{
    public static float PlayerMovementSpeed = 10f;
    
    public static int PlayerMaxHealth = 10;
    public static int PigeonMaxHealth = 2;
    public static int PenguinMaxHealth = 2;
    public static int HummingbirdMaxHealth = 1;
    public static int OstrichMaxHealth = 3;
    public static int GooseMaxHealth = 2;

    
    
    public static int NumberBirdsOnScreen = 1;
    public static float BirdsMinimumSecondsToWait = 3f;
    public static float BirdsMaximumSecondsToWait = 5f;
    public static float BirdMovementSpeed = 10f;
    public static float GooseMovementSpeed = 2f;
    public static float OstrichMovementSpeed = 5f;
    public static float SlowdownMultiplier = 0.5f;
    public static float BirdSpeedMultiplier = 1f;
    public static float SlowdownDuration = 8f;
    public static float DamageFlashDuration = 0.1f;
    
    public static float BulletMovementSpeed = 10f;
    public static int BulletDamage = 1;
    public static float BulletFireCooldown = 0.5f;
    public static float GooseFireCooldown = 1f;

    public static float LaserMovementSpeed = 30f;
    public static int LaserDamage = 2;
    public static float LaserFireCooldown = 0.1f;
    public static float LaserPowerUpDuration = 10f;
    public static float BoxDropChance = 0.5f;
    
    public static float PigeonRestTimeInSeconds = 1.5f;
    public static float BirdExistTimeInSeconds = 5f;
    public static float PigeonMovementSpeed = 3f;

}
